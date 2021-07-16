using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Connects <typeparamref name="THandler"/>.
    /// </summary>
    /// <typeparam name="THandler">
    /// Type of <see cref="IHandler"/> to connect.
    /// </typeparam>
    public interface IConnection<THandler>
        where THandler : IHandler
    {
        /// <summary>
        /// Connects <typeparamref name="THandler"/>.
        /// </summary>
        /// <param name="handler">
        /// <typeparamref name="THandler"/> to connect.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        ICancellation Connect(THandler handler);
    }
}
