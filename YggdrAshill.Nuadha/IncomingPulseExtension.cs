using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IIncomingFlow{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class IncomingPulseExtension
    {
        /// <summary>
        /// Imports <paramref name="flow"/> to send <see cref="Pulse"/>.
        /// </summary>
        /// <param name="incomingFlow">
        /// <see cref="IIncomingFlow{TSignal}"/> for <see cref="Pulse"/>.
        /// </param>
        /// <param name="flow">
        /// <see cref="Action"/> as <see cref="IOutgoingFlow{TSignal}"/> for <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        public static IDisposable Import(this IIncomingFlow<Pulse> incomingFlow, Action flow)
        {
            var outgoingFlow = new OutgoingPulse(flow);
            return incomingFlow.Import(outgoingFlow);
        }
    }
}
