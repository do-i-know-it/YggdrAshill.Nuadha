using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Connects <typeparamref name="TModule"/>.
    /// </summary>
    /// <typeparam name="TModule">
    /// Type of <see cref="IModule"/> to connect.
    /// </typeparam>
    public interface IConnection<TModule>
        where TModule : IModule
    {
        /// <summary>
        /// Connects <typeparamref name="TModule"/>.
        /// </summary>
        /// <param name="module">
        /// <typeparamref name="TModule"/> to connect.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        ICancellation Connect(TModule module);
    }
}
