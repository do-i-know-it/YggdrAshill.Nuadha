using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDetectionDevice :
        IDevice<IHandControllerDetectionSoftware>
    {
        private readonly StickDetectionDevice thumbStick;

        private readonly TriggerDetectionDevice fingerTrigger;
        
        private readonly TriggerDetectionDevice handTrigger;

        public HandControllerDetectionDevice(IHandControllerHardware hardware, IHandControllerThreshold threshold)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            thumbStick = new StickDetectionDevice(hardware.ThumbStick, threshold.ThumbStick);
            
            fingerTrigger = new TriggerDetectionDevice(hardware.FingerTrigger, threshold.FingerTrigger);
            
            handTrigger = new TriggerDetectionDevice(hardware.HandTrigger, threshold.HandTrigger);
        }

        public IDisconnection Connect(IHandControllerDetectionSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var thumbStick = this.thumbStick.Connect(software.ThumbStick);

            var fingerTrigger = this.fingerTrigger.Connect(software.FingerTrigger);

            var handTrigger = this.handTrigger.Connect(software.HandTrigger);

            return new Disconnection(() =>
            {
                thumbStick.Disconnect();

                fingerTrigger.Disconnect();

                handTrigger.Disconnect();
            });
        }
    }
}
