namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Defines hardware <see cref="IModule"/> and software <see cref="IModule"/>.
    /// </summary>
    /// <typeparam name="THardware">
    /// Type of <see cref="IModule"/> for hardware.
    /// </typeparam>
    /// <typeparam name="TSoftware">
    /// Type of <see cref="IModule"/> for software.
    /// </typeparam>
    public interface IProtocol<THardware, TSoftware> :
        IModule
        where THardware : IModule
        where TSoftware : IModule
    {
        /// <summary>
        /// <see cref="IModule"/> for hardware.
        /// </summary>
        THardware Hardware { get; }

        /// <summary>
        /// <see cref="IModule"/> for software.
        /// </summary>
        TSoftware Software { get; }
    }
}
