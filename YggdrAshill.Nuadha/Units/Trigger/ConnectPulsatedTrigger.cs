using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedTrigger :
        IConnection<IPulsatedTriggerSoftware>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> pull;

        internal ConnectPulsatedTrigger(ITriggerHardware module, HysteresisThreshold threshold)
        {
            touch = module.Touch.Convert(TouchInto.Pulse);

            pull = module.Pull.Convert(PullInto.Pulse(threshold));
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPulsatedTriggerSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            var composite = new CompositeCancellation();

            touch.Produce(module.Touch).Synthesize(composite);
            pull.Produce(module.Pull).Synthesize(composite);

            return composite;
        }
    }
}
