using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedHandController :
        IConnection<IPulsatedHandControllerHardwareHandler>
    {
        private readonly PulsatedStick thumb;

        private readonly PulsatedTrigger indexFinger;

        private readonly PulsatedTrigger handGrip;

        public PulsatedHandController(IHandControllerSoftwareHandler handler, HandControllerThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            thumb = new PulsatedStick(handler.Thumb, threshold.Thumb);

            indexFinger = new PulsatedTrigger(handler.IndexFinger, threshold.IndexFinger);

            handGrip = new PulsatedTrigger(handler.HandGrip, threshold.HandGrip);
        }

        public ICancellation Connect(IPulsatedHandControllerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            thumb.Connect(handler.Thumb).Synthesize(synthesized);
            indexFinger.Connect(handler.IndexFinger).Synthesize(synthesized);
            handGrip.Connect(handler.HandGrip).Synthesize(synthesized);

            return synthesized;
        }
    }
}
