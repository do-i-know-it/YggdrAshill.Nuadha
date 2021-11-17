using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Generates <typeparamref name="TSignal"/> in order to send to each of <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to transmit.
    /// </typeparam>
    public interface ITransmission<TSignal> :
        IProduction<TSignal>,
        IEmission,
        IDisposable
        where TSignal : ISignal
    {

    }
}
