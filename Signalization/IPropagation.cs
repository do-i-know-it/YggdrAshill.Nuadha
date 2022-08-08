using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Receives <typeparamref name="TSignal"/> to send.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to propagate.
    /// </typeparam>
    public interface IPropagation<TSignal> :
        IProduction<TSignal>,
        IConsumption<TSignal>,
        IDisposable
        where TSignal : ISignal
    {

    }
}
