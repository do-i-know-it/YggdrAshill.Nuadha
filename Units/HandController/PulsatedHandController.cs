using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PulsatedHandController :
        IConnection<IHandControllerPulsationSoftware>
    {
        private readonly PulsatedStick thumb;

        private readonly PulsatedTrigger indexFinger;

        private readonly PulsatedTrigger handGrip;

        public PulsatedHandController(IHandControllerHardware handler, IHandControllerThreshold threshold)
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

        public ICancellation Connect(IHandControllerPulsationSoftware handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return thumb.Connect(handler.Thumb)
                .Synthesize(indexFinger.Connect(handler.IndexFinger))
                .Synthesize(handGrip.Connect(handler.HandGrip));
        }
    }
}
