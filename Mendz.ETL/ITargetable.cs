namespace Mendz.ETL
{
    /// <summary>
    /// Defines a targetable source.
    /// </summary>
    public interface  ITargetable
    {
        /// <summary>
        /// When implemented by a source adapter,
        /// returns an instance of its target adapter counterpart
        /// with the source adapter's document specification copied over.
        /// </summary>
        /// <returns>The source adapter's target adapter counterpart.</returns>
        ITargetAdapter ToTargetAdapter();
    }
}
