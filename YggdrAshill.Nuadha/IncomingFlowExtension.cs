using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IIncomingFlow{TSignal}"/>.
    /// </summary>
    public static class IncomingFlowExtension
    {
        /// <summary>
        /// Imports <paramref name="flow"/> to send <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to import.
        /// </typeparam>
        /// <param name="incomingFlow">
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="flow">
        /// <see cref="Action{T}"/> as <see cref="IOutgoingFlow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public static IDisposable Import<TSignal>(this IIncomingFlow<TSignal> incomingFlow, Action<TSignal> flow)
            where TSignal : ISignal
        {
            var outgoingFlow = new OutgoingFlow<TSignal>(flow);
            return incomingFlow.Import(outgoingFlow);
        }
    }
}
