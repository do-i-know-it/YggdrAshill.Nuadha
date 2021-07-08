using System;

namespace YggdrAshill.Nuadha.Unitization.Experimental
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware and software.
    /// </summary>
    /// <typeparam name="THardware">
    /// Type of <see cref="IHandler"/> for hardware.
    /// </typeparam>
    /// <typeparam name="TSoftware">
    /// Type of <see cref="IHandler"/> for software.
    /// </typeparam>
    public interface IModule<THardware, TSoftware> :
        IDisposable
        where THardware : IHandler
        where TSoftware : IHandler
    {
        /// <summary>
        /// <see cref="IHandler"/> for hardware.
        /// </summary>
        THardware Hardware { get; }

        /// <summary>
        /// <see cref="IHandler"/> for software.
        /// </summary>
        TSoftware Software { get; }
    }
}
