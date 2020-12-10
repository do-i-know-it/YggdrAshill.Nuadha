using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerEventSystem :
        ISoftware<IHandControllerSoftwareHandler>,
        IHandControllerEventHandler,
        IDisconnection
    {
        private readonly StickEventSystem thumbStick;

        private readonly TriggerEventSystem fingerTrigger;
        
        private readonly TriggerEventSystem handTrigger;

        public HandControllerEventSystem(HysteresisThreshold thumbStick, HysteresisThreshold fingerTrigger, HysteresisThreshold handTrigger)
        {
            this.thumbStick = new StickEventSystem(thumbStick);
            
            this.fingerTrigger = new TriggerEventSystem(fingerTrigger);
            
            this.handTrigger = new TriggerEventSystem(handTrigger);
        }

        #region IHandControllerEventHandler

        public IStickEventHandler ThumbStick => thumbStick;

        public ITriggerEventHandler FingerTrigger => fingerTrigger;

        public ITriggerEventHandler HandTrigger => handTrigger;

        #endregion

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
