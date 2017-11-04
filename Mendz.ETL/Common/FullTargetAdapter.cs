using System.Collections.Generic;
using System.IO;

namespace Mendz.ETL.Common
{
    /// <summary>
    /// Represents a full load target adapter.
    /// </summary>
    public class FullTargetAdapter : TargetAdapterBase
    {
        /// <summary>
        /// Loads all to the target.
        /// </summary>
        /// <param name="output">The output to load.</param>
        protected override void LoadOutput(IEnumerable<string> output)
        {
            foreach (string data in output)
            {
                File.WriteAllText(TargetSpecification.Address, data);
            }
        }
    }
}
