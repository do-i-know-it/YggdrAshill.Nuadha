using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Sends <typeparamref name="TSignal"/> to <see cref="IOutgoingFlow{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to send.
    /// </typeparam>
    public interface IIncomingFlow<out TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Imports <paramref name="outgoingFlow"/> to send <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="outgoingFlow">
        /// <see cref="IOutgoingFlow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        IDisposable Import(IOutgoingFlow<TSignal> outgoingFlow);
    }
}
