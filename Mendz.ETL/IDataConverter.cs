namespace Mendz.ETL
{
    /// <summary>
    /// Defines a data converter.
    /// </summary>
    /// <typeparam name="T">The type of data. Can be a POCO type, for example.</typeparam>
    /// <remarks>
    /// Representing data to/from T allows developers to work with data
    /// in a more object-oriented fashion, in addition to making codes more readable.
    /// It also makes it simpler to use data in LINQ and in LINQ-compatible operations.
    /// IDataConverter implementations are in many ways like (de-)serializers
    /// and can in fact be just wrappers to T's (de-)serializer.
    /// Note that Mendz.ETL.IData* implementations can also share data with each other.
    /// </remarks>
    public interface IDataConverter<T>
    {
        /// <summary>
        /// Converts data to a type instance.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <returns>The converted data.</returns>
        T Convert(string data);

        /// <summary>
        /// Reverts a data instance to its ETL flow-compatible format.
        /// </summary>
        /// <param name="data">The data to revert.</param>
        /// <returns>The reverted data.</returns>
        string Revert(T data);
    }
}
