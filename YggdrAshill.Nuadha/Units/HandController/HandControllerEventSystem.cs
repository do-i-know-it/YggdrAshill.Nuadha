using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerEventSystem :
        ISoftware<IHandControllerSoftwareHandler>,
        IDisconnection
    {
        private readonly StickEventSystem thumbStick;

        private readonly TriggerEventSystem fingerTrigger;
        
        private readonly TriggerEventSystem handTrigger;

        public HandControllerEventSystem(IHandControllerThreshold threshold, IHandControllerEventInputHandler handler)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            thumbStick = new StickEventSystem(threshold.ThumbStick, handler.ThumbStick);
            
            fingerTrigger = new TriggerEventSystem(threshold.FingerTrigger, handler.FingerTrigger);
            
            handTrigger = new TriggerEventSystem(threshold.HandTrigger, handler.HandTrigger);
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
