using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// The base mapper.
    /// </summary>
    public abstract class MapperBase : IMapper
    {
        public event ETLMapperEventHandler OnMapperStart;
        public event ETLMapperEventHandler OnTransforming;
        public event ETLMapperEventHandler OnTransformed;
        public event ETLMapperEventHandler OnMapperEnd;

        public virtual IEnumerable<string> Transform(IEnumerable<string> input, 
            DocumentSpecification sourceSpecification, 
            DocumentSpecification targetSpecification)
        {
            ETLMapperEventArgs e = new ETLMapperEventArgs()
            {
                SourceSpecification = sourceSpecification,
                TargetSpecification = targetSpecification
            };
            OnMapperStart?.Invoke(this, e);
            foreach (var item in input)
            {
                e.Input = item;
                OnTransforming?.Invoke(this, e);
                e.Output = TransformInputToOutput(item, e.SourceSpecification, e.TargetSpecification);
                e.Counter++;
                OnTransformed?.Invoke(this, e);
                yield return e.Output;
            }
            OnMapperEnd?.Invoke(this, e);
        }

        /// <summary>
        /// Transforms the input to the output.
        /// </summary>
        /// <param name="input">The input to transform.</param>
        /// <param name="sourceSpecification">The source's document specification.</param>
        /// <param name="targetSpecification">The target's document specification.</param>
        /// <returns>The transformation output.</returns>
        protected abstract string TransformInputToOutput(string input, DocumentSpecification sourceSpecification, DocumentSpecification targetSpecification);
    }
}
