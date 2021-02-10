using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDetectionSystem :
        ISoftware<IHandControllerSoftwareHandler>,
        IHardware<IHandControllerDetectionHardwareHandler>,
        IDisconnection
    {
        private readonly StickDetectionSystem thumbStick;

        private readonly TriggerDetectionSystem fingerTrigger;
        
        private readonly TriggerDetectionSystem handTrigger;

        public HandControllerDetectionSystem(IHandControllerThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            thumbStick = new StickDetectionSystem(threshold.ThumbStick);
            
            fingerTrigger = new TriggerDetectionSystem(threshold.FingerTrigger);
            
            handTrigger = new TriggerDetectionSystem(threshold.HandTrigger);
        }

        #region ISoftware

        public IDisconnection Connect(IHandControllerSoftwareHandler handler)
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

        #endregion

        #region IHardware

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

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            thumbStick.Disconnect();

            fingerTrigger.Disconnect();

            handTrigger.Disconnect();
        }

        #endregion
    }
}
