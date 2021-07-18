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
    /// Can be combined with <see cref="IGeneration{TSignal}"/> to generate <see cref="ITransmission{TSignal}"/>.
    /// In detail, please see <see cref="PropagationExtension.Transmit{TSignal}(IPropagation{TSignal}, IGeneration{TSignal})"/>.
    /// </remarks>
    public interface IPropagation<TSignal> :
        IProduction<TSignal>,
        IConsumption<TSignal>,
        IDisposable
        where TSignal : ISignal
    {

    }
}
