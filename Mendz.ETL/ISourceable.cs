namespace Mendz.ETL
{
    /// <summary>
    /// Defines a sourceable target.
    /// </summary>
    public interface ISourceable
    {
        /// <summary>
        /// When implemented by a target adapter,
        /// returns an instance of its source adapter counterpart
        /// with the target adapter's document specification copied over.
        /// </summary>
        /// <returns>The target adapter's source adapter counterpart.</returns>
        ISourceAdapter ToSourceAdapter();
    }
}
