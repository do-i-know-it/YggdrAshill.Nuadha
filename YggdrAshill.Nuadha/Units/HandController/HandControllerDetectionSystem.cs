using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDetectionSystem :
        IHardware<IHandControllerDetectionHardwareHandler>
    {
        private readonly StickDetectionSystem thumbStick;

        private readonly TriggerDetectionSystem fingerTrigger;
        
        private readonly TriggerDetectionSystem handTrigger;

        public HandControllerDetectionSystem(IHandControllerSoftwareHandler handler, IHandControllerThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            thumbStick = new StickDetectionSystem(handler.ThumbStick, threshold.ThumbStick);
            
            fingerTrigger = new TriggerDetectionSystem(handler.FingerTrigger, threshold.FingerTrigger);
            
            handTrigger = new TriggerDetectionSystem(handler.HandTrigger, threshold.HandTrigger);
        }

        public IDisconnection Connect(IHandControllerDetectionHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var thumbStick = this.thumbStick.Connect(handler.ThumbStick);

            var fingerTrigger = this.fingerTrigger.Connect(handler.FingerTrigger);

            var handTrigger = this.handTrigger.Connect(handler.HandTrigger);

            return new Disconnection(() =>
            {
                thumbStick.Disconnect();

                fingerTrigger.Disconnect();

                handTrigger.Disconnect();
            });
        }
    }
}
