using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerEventSystem :
        IHandControllerEventSystem
    {
        private readonly IStickEventSystem thumbStick;

        private readonly ITriggerEventSystem fingerTrigger;
        
        private readonly ITriggerEventSystem handTrigger;

        public HandControllerEventSystem(IStickEventSystem thumbStick, ITriggerEventSystem fingerTrigger, ITriggerEventSystem handTrigger)
        {
            if (thumbStick == null)
            {
                throw new ArgumentNullException(nameof(thumbStick));
            }
            if (fingerTrigger == null)
            {
                throw new ArgumentNullException(nameof(fingerTrigger));
            }
            if (handTrigger == null)
            {
                throw new ArgumentNullException(nameof(handTrigger));
            }

            this.thumbStick = thumbStick;
            
            this.fingerTrigger = fingerTrigger;
            
            this.handTrigger = handTrigger;
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
