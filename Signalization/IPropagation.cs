using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Propagates <typeparamref name="TSignal"/> to each connected <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to propagate.
    /// </typeparam>
    /// <remarks>
    /// This is <see cref="IProduction{TSignal}"/> and <see cref="IConsumption{TSignal}"/>.
    /// </remarks>
    public interface IPropagation<TSignal> :
        IProduction<TSignal>,
        IConsumption<TSignal>,
        IDisposable
        where TSignal : ISignal
    {

    }
}
