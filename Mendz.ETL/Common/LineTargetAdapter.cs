using System.Collections.Generic;
using System.IO;

namespace Mendz.ETL.Common
{
    /// <summary>
    /// Represents a line target adapter.
    /// </summary>
    public class LineTargetAdapter : TargetAdapterBase
    {
        /// <summary>
        /// Loads lines to the target.
        /// </summary>
        /// <param name="output">The output to load.</param>
        protected override void LoadOutput(IEnumerable<string> output)
        {
            using (StreamWriter sw = new StreamWriter(TargetSpecification.Address))
            {
                foreach (string data in output)
                {
                    sw.WriteLine(data);
                }
                sw.Flush();
                sw.Close();
            }
        }
    }
}
