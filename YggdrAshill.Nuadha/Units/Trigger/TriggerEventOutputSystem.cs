using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerEventOutputSystem :
        ISoftware<ITriggerEventOutputHandler>
    {
        private readonly ITriggerEventInputHandler inputHandler;

        public TriggerEventOutputSystem(ITriggerEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(ITriggerEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasTouched = handler.Touch.HasTouched.Connect(inputHandler.Touch.HasTouched);
            var isTouched = handler.Touch.IsTouched.Connect(inputHandler.Touch.IsTouched);
            var touchHasReleased = handler.Touch.HasReleased.Connect(inputHandler.Touch.HasReleased);
            var touchIsReleased = handler.Touch.IsReleased.Connect(inputHandler.Touch.IsReleased);

            var hasPulled = handler.Pull.HasPulled.Connect(inputHandler.Pull.HasPulled);
            var isPulled = handler.Pull.IsPulled.Connect(inputHandler.Pull.IsPulled);
            var pullHasReleased = handler.Pull.HasReleased.Connect(inputHandler.Pull.HasReleased);
            var pullIsReleased = handler.Pull.IsReleased.Connect(inputHandler.Pull.IsReleased);

            return new Disconnection(() =>
            {
                hasTouched.Disconnect();
                isTouched.Disconnect();
                touchHasReleased.Disconnect();
                touchIsReleased.Disconnect();

                hasPulled.Disconnect();
                isPulled.Disconnect();
                pullHasReleased.Disconnect();
                pullIsReleased.Disconnect();
            });
        }
    }
}
