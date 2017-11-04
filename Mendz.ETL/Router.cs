using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendz.ETL
{
    /// <summary>
    /// The ETL router.
    /// </summary>
    public static class Router
    {
        /// <summary>
        /// Routes the source to a target via mapper.
        /// </summary>
        /// <param name="source">The source adapter.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="target">The target adapter.</param>
        public static void Route(ISourceAdapter source, IMapper mapper, ITargetAdapter target)
        {
            target.Load(
                mapper.Transform(
                    source.Extract(), source.SourceSpecification, target.TargetSpecification));
        }

        /// <summary>
        /// Chain routes from a source to a series of targets.
        /// </summary>
        /// <param name="source">The starting source adapter.</param>
        /// <param name="chain">The series of mappers and target adapters.</param>
        /// <remarks>
        /// The chaining targets should be ISourceable.
        /// If the iterated target is not ISourceable, the "chain" breaks/stops.
        /// </remarks>
        public static void ChainRoute(ISourceAdapter source, IList<(IMapper mapper, ITargetAdapter target)> chain)
        {
            ISourceAdapter s = source;
            foreach (var routing in chain)
            {
                ITargetAdapter t = routing.target;
                Route(s, routing.mapper, t);
                if (t is ISourceable ts)
                {
                    s = ts.ToSourceAdapter();
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Merge routes sources to a target.
        /// </summary>
        /// <param name="sources">The collection of source adapter and mapper pairs to merge from.</param>
        /// <param name="target">The target adapter.</param>
        public static void MergeRoute(IList<(ISourceAdapter source, IMapper mapper)> sources, ITargetAdapter target)
        {
            foreach (var merge in sources)
            {
                Route(merge.source, merge.mapper, target);
            }
        }

        /// <summary>
        /// Split routes a source to a collection of targets.
        /// </summary>
        /// <param name="source">The source adapter.</param>
        /// <param name="targets">The collection of mapper and target adapter pairs to split to.</param>
        public static void SplitRoute(ISourceAdapter source, IList<(IMapper mapper, ITargetAdapter target)> targets)
        {
            List<BlockingCollection<string>> lbc = new List<BlockingCollection<string>>();
            List<Task> lt = new List<Task>();
            int targetCount = targets.Count;
            for (int i = 0; i < targetCount; i++)
            {
                lbc.Add(new BlockingCollection<string>());
                lt.Add(Task.Factory.StartNew(() => 
                {
                    targets[i].target.Load(
                        targets[i].mapper.Transform(
                            lbc[i].GetConsumingEnumerable(), 
                            source.SourceSpecification, targets[i].target.TargetSpecification));
                }, TaskCreationOptions.AttachedToParent & TaskCreationOptions.LongRunning));
            }
            foreach (var input in source.Extract())
            {
                for (int i = 0; i < targetCount; i++)
                {
                    lbc[i].Add(input);
                }
            }
            for (int i = 0; i < targetCount; i++)
            {
                lbc[i].CompleteAdding();
            }
            Task.WaitAll(lt.ToArray());
            for (int i = 0; i < targetCount; i++)
            {
                lt[i].Dispose();
                lbc[i].Dispose();
            }
        }

        /// <summary>
        /// Join routes a collection of sources to a target.
        /// </summary>
        /// <param name="joiner">The joiner.</param>
        /// <param name="sources">The source adapters to join.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="target">The target adapter.</param>
        public static void JoinRoute(IJoiner joiner, IList<ISourceAdapter> sources, IMapper mapper, ITargetAdapter target)
        {
            target.Load(
                mapper.Transform(
                    joiner.Join(sources), joiner.JoinedSourcesSpecification, target.TargetSpecification));
        }

        /// <summary>
        /// Joins a collections of sources and splits them to a collection of targets.
        /// </summary>
        /// <param name="joiner">The joiner.</param>
        /// <param name="sources">The source adapters to join.</param>
        /// <param name="targets">The collection of mapper and target adapter pairs to split to.</param>
        public static void JoinSplitRoute(IJoiner joiner, IList<ISourceAdapter> sources, IList<(IMapper mapper, ITargetAdapter target)> targets)
        {
            List<BlockingCollection<string>> lbc = new List<BlockingCollection<string>>();
            List<Task> lt = new List<Task>();
            int targetCount = targets.Count;
            for (int i = 0; i < targetCount; i++)
            {
                lbc.Add(new BlockingCollection<string>());
                lt.Add(Task.Factory.StartNew(() =>
                {
                    targets[i].target.Load(
                        targets[i].mapper.Transform(
                            lbc[i].GetConsumingEnumerable(),
                            joiner.JoinedSourcesSpecification, targets[i].target.TargetSpecification));
                }, TaskCreationOptions.AttachedToParent & TaskCreationOptions.LongRunning));
            }
            foreach (var item in joiner.Join(sources))
            {
                for (int i = 0; i < targetCount; i++)
                {
                    lbc[i].Add(item);
                }
            }
            for (int i = 0; i < targetCount; i++)
            {
                lbc[i].CompleteAdding();
            }
            Task.WaitAll(lt.ToArray());
            for (int i = 0; i < targetCount; i++)
            {
                lt[i].Dispose();
                lbc[i].Dispose();
            }
        }
    }
}
