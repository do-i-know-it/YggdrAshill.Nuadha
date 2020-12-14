using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerEventOutputSystem :
        ISoftware<IHandControllerEventOutputHandler>
    {
        private readonly StickEventOutputSystem thumbStick;

        private readonly TriggerEventOutputSystem fingerTrigger;
        
        private readonly TriggerEventOutputSystem handTrigger;

        public HandControllerEventOutputSystem(IHandControllerEventInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            thumbStick = new StickEventOutputSystem(handler.ThumbStick);

            fingerTrigger = new TriggerEventOutputSystem(handler.FingerTrigger);

            handTrigger = new TriggerEventOutputSystem(handler.HandTrigger);
        }

        public IDisconnection Connect(IHandControllerEventOutputHandler handler)
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
