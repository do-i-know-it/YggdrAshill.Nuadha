using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Transmits <typeparamref name="TSignal"/> to <see cref="IOutgoingFlow{TSignal}"/>s.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to transmit.
    /// </typeparam>
    public interface IFlow<TSignal> : IIncomingFlow<TSignal>, IOutgoingFlow<TSignal>, IDisposable
        where TSignal : ISignal
    {

    }
}
