using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Connects <typeparamref name="THardware"/> to send and receive <see cref="ISignal"/>.
    /// </summary>
    /// <typeparam name="THardware">
    /// <see cref="IHardware"/> to connect.
    /// </typeparam>
    public interface ISystem<THardware>
        where THardware : IHardware
    {
        /// <summary>
        /// Connects <typeparamref name="THardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHardware"/> to connect.
        /// </param>
        /// <returns>
        /// <see cref="IDisconnection"/> to disconnect.
        /// </returns>
        IDisconnection Connect(THardware hardware);
    }
}
