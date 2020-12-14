using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchEventOutputSystem :
        ISoftware<ITouchEventOutputHandler>
    {
        private readonly ITouchEventInputHandler inputHandler;

        public TouchEventOutputSystem(ITouchEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(ITouchEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasTouched = handler.HasTouched.Connect(inputHandler.HasTouched);

            var isTouched = handler.IsTouched.Connect(inputHandler.IsTouched);

            var hasReleased = handler.HasReleased.Connect(inputHandler.HasReleased);

            var isReleased = handler.IsReleased.Connect(inputHandler.IsReleased);

            return new Disconnection(() =>
            {
                hasTouched.Disconnect();

                isTouched.Disconnect();

                hasReleased.Disconnect();

                isReleased.Disconnect();
            });
        }
    }
}
