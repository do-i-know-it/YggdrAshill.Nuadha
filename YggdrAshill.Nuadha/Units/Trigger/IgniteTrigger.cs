using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteTrigger :
        IIgnition<ITriggerSoftware>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Pull> pull;

        internal IgniteTrigger(Trigger protocol, ITriggerConfiguration configuration)
        {
            touch = protocol.Touch.Transmit(configuration.Touch);

            pull = protocol.Pull.Transmit(configuration.Pull);
        }

        /// <inheritdoc/>
        public ICancellation Connect(ITriggerSoftware handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var composite = new CompositeCancellation();

            touch.Produce(handler.Touch).Synthesize(composite);
            pull.Produce(handler.Pull).Synthesize(composite);

            return composite;
        }

        /// <inheritdoc/>
        public void Emit()
        {
            touch.Emit();

            pull.Emit();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }
    }
}
