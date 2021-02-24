using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Connects <typeparamref name="TSoftware"/> to send and receive <see cref="ISignal"/>.
    /// </summary>
    /// <typeparam name="TSoftware">
    /// <see cref="ISoftware"/> to connect.
    /// </typeparam>
    public interface IDevice<TSoftware>
        where TSoftware : ISoftware
    {
        /// <summary>
        /// Connects <typeparamref name="TSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="ISoftware"/> to connect.
        /// </param>
        /// <returns>
        /// <see cref="IDisconnection"/> to disconnect.
        /// </returns>
        IDisconnection Connect(TSoftware software);
    }
}
