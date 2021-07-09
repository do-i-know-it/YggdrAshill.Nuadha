using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class PulsatedTrigger :
        IConnection<IPulsatedTriggerHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> pull;

        internal PulsatedTrigger(ITriggerSoftwareHandler handler, HysteresisThreshold threshold)
        {
            touch = handler.Touch.Convert(SignalInto.Pulse(WhenSignalOf.TouchIs.Enabled));

            pull = handler.Pull.Convert(threshold);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPulsatedTriggerHardwareHandler handler)
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
    }
}
