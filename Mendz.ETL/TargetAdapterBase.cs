using System.Collections.Generic;

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
            foreach (var item in output)
            {
                e.Output = item;
                OnLoading?.Invoke(this, e);
                LoadOutput(e.Output);
                OnLoaded?.Invoke(this, e);
            }
            if (TargetValidator != null)
            {
                TargetValidator.Validate(TargetSpecification);
            }
            OnTargetAdapterEnd?.Invoke(this, e);
        }

        /// <summary>
        /// Loads the output to the target.
        /// </summary>
        /// <param name="output">The output to load.</param>
        protected abstract void LoadOutput(string output);

        DocumentSpecification ITargetAdapter.TargetSpecification
        {
            get => TargetSpecification;
            set => TargetSpecification = value;
        }

        IValidator ITargetAdapter.TargetValidator
        {
            get => TargetValidator;
            set => TargetValidator = value;
        }

        void ITargetAdapter.Load(IEnumerable<string> output) => Load(output);
    }
}
