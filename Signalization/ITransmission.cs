using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Transmits <typeparamref name="TSignal"/> to each <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to transmit.
    /// </typeparam>
    /// <remarks>
    /// This is <see cref="IProduction{TSignal}"/> and <see cref="IEmission"/>.
    /// </remarks>
    public interface ITransmission<TSignal> :
        IProduction<TSignal>,
        IEmission,
        IDisposable
        where TSignal : ISignal
    {

    }
}
