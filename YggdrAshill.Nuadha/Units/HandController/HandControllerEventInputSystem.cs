using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerEventInputSystem :
        ISoftware<IHandControllerSoftwareHandler>,
        IHandControllerEventOutputHandler,
        IDisconnection
    {
        private readonly StickEventInputSystem thumbStick;

        private readonly TriggerEventInputSystem fingerTrigger;
        
        private readonly TriggerEventInputSystem handTrigger;

        public HandControllerEventInputSystem(IHandControllerThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            thumbStick = new StickEventInputSystem(threshold.ThumbStick);
            
            fingerTrigger = new TriggerEventInputSystem(threshold.FingerTrigger);
            
            handTrigger = new TriggerEventInputSystem(threshold.HandTrigger);
        }

        #region IHandControllerEventOutputHandler

        public IStickEventOutputHandler ThumbStick => thumbStick;

        public ITriggerEventOutputHandler FingerTrigger => fingerTrigger;

        public ITriggerEventOutputHandler HandTrigger => handTrigger;

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
