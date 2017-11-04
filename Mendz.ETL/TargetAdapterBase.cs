using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendz.ETL
{
    /// <summary>
    /// The base target adapter.
    /// </summary>
    public abstract class TargetAdapterBase : ITargetAdapter
    {
        public event ETLTargetAdapterEventHandler OnTargetAdapterStart;
        public event ETLTargetAdapterEventHandler OnLoading;
        public event ETLTargetAdapterEventHandler OnLoaded;
        public event ETLTargetAdapterEventHandler OnTargetAdapterEnd;

        public DocumentSpecification TargetSpecification { get; set; }

        public virtual IValidator TargetValidator { get; set; }

        public virtual void Load(IEnumerable<string> output)
        {
            ETLTargetAdapterEventArgs e = new ETLTargetAdapterEventArgs()
            {
                TargetSpecification = TargetSpecification
            };
            OnTargetAdapterStart?.Invoke(this, e);
            using (BlockingCollection<string> bc = new BlockingCollection<string>())
            {
                using (Task t = Task.Factory.StartNew(() => 
                    LoadOutput(bc.GetConsumingEnumerable()),
                    TaskCreationOptions.AttachedToParent & TaskCreationOptions.LongRunning))
                {
                    foreach (var item in output)
                    {
                        e.Output = item;
                        OnLoading?.Invoke(this, e);
                        bc.Add(e.Output);
                        e.Counter++;
                        OnLoaded?.Invoke(this, e);
                    }
                    bc.CompleteAdding();
                    t.Wait();
                }
            }
            if (TargetValidator != null)
            {
                e.IsValid = TargetValidator.Validate(TargetSpecification);
            }
            OnTargetAdapterEnd?.Invoke(this, e);
        }

        /// <summary>
        /// Loads the output to the target.
        /// </summary>
        /// <param name="output">The output to load.</param>
        protected abstract void LoadOutput(IEnumerable<string> output);
    }
}
