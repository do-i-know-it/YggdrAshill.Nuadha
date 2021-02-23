using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDetectionDevice :
        IHardware<IHandControllerDetectionSystem>
    {
        private readonly StickDetectionDevice thumbStick;

        private readonly TriggerDetectionDevice fingerTrigger;
        
        private readonly TriggerDetectionDevice handTrigger;

        public HandControllerDetectionDevice(IHandControllerDevice device, IHandControllerThreshold threshold)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            thumbStick = new StickDetectionDevice(device.ThumbStick, threshold.ThumbStick);
            
            fingerTrigger = new TriggerDetectionDevice(device.FingerTrigger, threshold.FingerTrigger);
            
            handTrigger = new TriggerDetectionDevice(device.HandTrigger, threshold.HandTrigger);
        }

        public IDisconnection Connect(IHandControllerDetectionSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var thumbStick = this.thumbStick.Connect(system.ThumbStick);

            var fingerTrigger = this.fingerTrigger.Connect(system.FingerTrigger);

            var handTrigger = this.handTrigger.Connect(system.HandTrigger);

            return new Disconnection(() =>
            {
                thumbStick.Disconnect();

                fingerTrigger.Disconnect();

                handTrigger.Disconnect();
            });
        }
    }
}
