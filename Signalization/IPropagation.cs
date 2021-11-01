using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Receives <typeparamref name="TSignal"/> in order to send to each of <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to propagate.
    /// </typeparam>
    /// <remarks>
    public interface IPropagation<TSignal> :
        IProduction<TSignal>,
        IConsumption<TSignal>,
        IDisposable
        where TSignal : ISignal
    {

    }
}
