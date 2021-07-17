using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteTrigger :
        IIgnition<ITriggerHardwareHandler>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Pull> pull;

        internal IgniteTrigger(TriggerModule module, ITriggerConfiguration configuration)
        {
            touch = module.Touch.Transmit(configuration.Touch);

            pull = module.Pull.Transmit(configuration.Pull);
        }

        /// <inheritdoc/>
        public ICancellation Connect(ITriggerHardwareHandler handler)
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
