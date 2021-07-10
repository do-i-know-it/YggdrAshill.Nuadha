namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware and software.
    /// </summary>
    /// <typeparam name="THardwareHandler">
    /// Type of <see cref="IHandler"/> for hardware.
    /// </typeparam>
    /// <typeparam name="TSoftwareHandler">
    /// Type of <see cref="IHandler"/> for software.
    /// </typeparam>
    public interface IModule<THardwareHandler, TSoftwareHandler>
        where THardwareHandler : IHandler
        where TSoftwareHandler : IHandler
    {
        /// <summary>
        /// <see cref="IHandler"/> for hardware.
        /// </summary>
        THardwareHandler HardwareHandler { get; }

        /// <summary>
        /// <see cref="IHandler"/> for software.
        /// </summary>
        TSoftwareHandler SoftwareHandler { get; }
    }
}
