using System.Collections.Generic;
using System.IO;

namespace Mendz.ETL.Common
{
    /// <summary>
    /// Represents a full extract source adapter. 
    /// </summary>
    public class FullSourceAdapter : SourceAdapterBase
    {
        /// <summary>
        /// Extracts all from the source.
        /// </summary>
        /// <returns>The extracted input.</returns>
        protected override IEnumerable<string> ExtractInput() => new string[1] { File.ReadAllText(SourceSpecification.Address) };
    }
}
