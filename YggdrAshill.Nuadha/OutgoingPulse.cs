using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IOutgoingFlow{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public sealed class OutgoingPulse : IOutgoingFlow<Pulse>
    {
        public static OutgoingPulse None { get; } = new(() => { });

        private readonly Action onExported;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="onExported">
        /// <see cref="Action"/> to export <see cref="Pulse"/>.
        /// </param>
        public OutgoingPulse(Action onExported)
        {
            this.onExported = onExported;
        }

        /// <inheritdoc/>
        public void Export(Pulse signal)
        {
            onExported.Invoke();
        }
    }
}
