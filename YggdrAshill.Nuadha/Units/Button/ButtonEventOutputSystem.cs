using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonEventOutputSystem :
        ISoftware<IButtonEventOutputHandler>
    {
        private readonly IButtonEventInputHandler inputHandler;

        public ButtonEventOutputSystem(IButtonEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(IButtonEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasTouched = handler.Touch.HasTouched.Connect(inputHandler.Touch.HasTouched);
            var isTouched = handler.Touch.IsTouched.Connect(inputHandler.Touch.IsTouched);
            var touchHasReleased = handler.Touch.HasReleased.Connect(inputHandler.Touch.HasReleased);
            var touchIsReleased = handler.Touch.IsReleased.Connect(inputHandler.Touch.IsReleased);

            var hasPushed = handler.Push.HasPushed.Connect(inputHandler.Push.HasPushed);
            var isPushed = handler.Push.IsPushed.Connect(inputHandler.Push.IsPushed);
            var pushHasReleased = handler.Push.HasReleased.Connect(inputHandler.Push.HasReleased);
            var pushIsReleased = handler.Push.IsReleased.Connect(inputHandler.Push.IsReleased);

            return new Disconnection(() =>
            {
                hasTouched.Disconnect();
                isTouched.Disconnect();
                touchHasReleased.Disconnect();
                touchIsReleased.Disconnect();

                hasPushed.Disconnect();
                isPushed.Disconnect();
                pushHasReleased.Disconnect();
                pushIsReleased.Disconnect();
            });
        }
    }
}
