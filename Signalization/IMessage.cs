using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Transmits <typeparamref name="TSignal"/> to <see cref="IOutgoingMessage{TSignal}"/>s.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to transmit.
    /// </typeparam>
    public interface IMessage<TSignal> : IIncomingMessage<TSignal>, IOutgoingMessage<TSignal>, IDisposable
        where TSignal : ISignal
    {

    }
}
