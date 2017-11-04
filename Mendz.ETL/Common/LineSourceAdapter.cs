using System.Collections.Generic;
using System.IO;

namespace Mendz.ETL.Common
{
    /// <summary>
    /// Represents a line source adapter.
    /// </summary>
    public class LineSourceAdapter : SourceAdapterBase
    {
        /// <summary>
        /// Extracts lines from the source.
        /// </summary>
        /// <returns>The extracted input.</returns>
        protected override IEnumerable<string> ExtractInput()
        {
            using (StreamReader sr = new StreamReader(SourceSpecification.Address))
            {
                while (sr.Peek() > -1)
                {
                    yield return sr.ReadLine();
                }
                sr.Close();
            }
        }
    }
}
