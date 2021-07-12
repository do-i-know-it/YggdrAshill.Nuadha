using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
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

            var synthesized = new SynthesizedCancellation();

            touch.Produce(handler.Touch).Synthesize(synthesized);
            pull.Produce(handler.Pull).Synthesize(synthesized);

            return synthesized;
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
