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

            var upHasPulled = handler.Tilt.Up.HasPulled.Connect(inputHandler.Tilt.Up.HasPulled);
            var upIsPulled = handler.Tilt.Up.IsPulled.Connect(inputHandler.Tilt.Up.IsPulled);
            var upHasReleased = handler.Tilt.Up.HasReleased.Connect(inputHandler.Tilt.Up.HasReleased);
            var upIsReleased = handler.Tilt.Up.IsReleased.Connect(inputHandler.Tilt.Up.IsReleased);

            var downHasPulled = handler.Tilt.Down.HasPulled.Connect(inputHandler.Tilt.Down.HasPulled);
            var downIsPulled = handler.Tilt.Down.IsPulled.Connect(inputHandler.Tilt.Down.IsPulled);
            var downHasReleased = handler.Tilt.Down.HasReleased.Connect(inputHandler.Tilt.Down.HasReleased);
            var downIsReleased = handler.Tilt.Down.IsReleased.Connect(inputHandler.Tilt.Down.IsReleased);

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

                upHasPulled.Disconnect();
                upIsPulled.Disconnect();
                upHasReleased.Disconnect();
                upIsReleased.Disconnect();

                downHasPulled.Disconnect();
                downIsPulled.Disconnect();
                downHasReleased.Disconnect();
                downIsReleased.Disconnect();
            });
        }
    }
}
