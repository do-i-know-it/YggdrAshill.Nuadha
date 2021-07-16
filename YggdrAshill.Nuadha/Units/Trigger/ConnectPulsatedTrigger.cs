using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedTrigger :
        IConnection<IPulsatedTriggerHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> pull;

        internal ConnectPulsatedTrigger(ITriggerSoftwareHandler handler, HysteresisThreshold threshold)
        {
            touch = handler.Touch.Convert(TouchInto.Pulse);

            pull = handler.Pull.Convert(PullInto.Pulse(threshold));
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
