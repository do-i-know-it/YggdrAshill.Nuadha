using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickEventOutputSystem :
        ISoftware<IStickEventOutputHandler>
    {
        private readonly IStickEventInputHandler inputHandler;

        public StickEventOutputSystem(IStickEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(IStickEventOutputHandler handler)
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

            var centerHasPulled = handler.Tilt.Center.HasPulled.Connect(inputHandler.Tilt.Center.HasPulled);
            var centerIsPulled = handler.Tilt.Center.IsPulled.Connect(inputHandler.Tilt.Center.IsPulled);
            var centerHasReleased = handler.Tilt.Center.HasReleased.Connect(inputHandler.Tilt.Center.HasReleased);
            var centerIsReleased = handler.Tilt.Center.IsReleased.Connect(inputHandler.Tilt.Center.IsReleased);

            var leftHasPulled = handler.Tilt.Left.HasPulled.Connect(inputHandler.Tilt.Left.HasPulled);
            var leftIsPulled = handler.Tilt.Left.IsPulled.Connect(inputHandler.Tilt.Left.IsPulled);
            var leftHasReleased = handler.Tilt.Left.HasReleased.Connect(inputHandler.Tilt.Left.HasReleased);
            var leftIsReleased = handler.Tilt.Left.IsReleased.Connect(inputHandler.Tilt.Left.IsReleased);

            var rightHasPulled = handler.Tilt.Right.HasPulled.Connect(inputHandler.Tilt.Right.HasPulled);
            var rightIsPulled = handler.Tilt.Right.IsPulled.Connect(inputHandler.Tilt.Right.IsPulled);
            var rightHasReleased = handler.Tilt.Right.HasReleased.Connect(inputHandler.Tilt.Right.HasReleased);
            var rightIsReleased = handler.Tilt.Right.IsReleased.Connect(inputHandler.Tilt.Right.IsReleased);

            var forwardHasPulled = handler.Tilt.Forward.HasPulled.Connect(inputHandler.Tilt.Forward.HasPulled);
            var forwardIsPulled = handler.Tilt.Forward.IsPulled.Connect(inputHandler.Tilt.Forward.IsPulled);
            var forwardHasReleased = handler.Tilt.Forward.HasReleased.Connect(inputHandler.Tilt.Forward.HasReleased);
            var forwardIsReleased = handler.Tilt.Forward.IsReleased.Connect(inputHandler.Tilt.Forward.IsReleased);

            var backwardHasPulled = handler.Tilt.Backward.HasPulled.Connect(inputHandler.Tilt.Backward.HasPulled);
            var backwardIsPulled = handler.Tilt.Backward.IsPulled.Connect(inputHandler.Tilt.Backward.IsPulled);
            var backwardHasReleased = handler.Tilt.Backward.HasReleased.Connect(inputHandler.Tilt.Backward.HasReleased);
            var backwardIsReleased = handler.Tilt.Backward.IsReleased.Connect(inputHandler.Tilt.Backward.IsReleased);

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

                centerHasPulled.Disconnect();
                centerIsPulled.Disconnect();
                centerHasReleased.Disconnect();
                centerIsReleased.Disconnect();

                leftHasPulled.Disconnect();
                leftIsPulled.Disconnect();
                leftHasReleased.Disconnect();
                leftIsReleased.Disconnect();

                rightHasPulled.Disconnect();
                rightIsPulled.Disconnect();
                rightHasReleased.Disconnect();
                rightIsReleased.Disconnect();

                forwardHasPulled.Disconnect();
                forwardIsPulled.Disconnect();
                forwardHasReleased.Disconnect();
                forwardIsReleased.Disconnect();

                backwardHasPulled.Disconnect();
                backwardIsPulled.Disconnect();
                backwardHasReleased.Disconnect();
                backwardIsReleased.Disconnect();
            });
        }
    }
}
