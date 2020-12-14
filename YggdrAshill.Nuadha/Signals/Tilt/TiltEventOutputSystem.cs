using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventOutputSystem :
        ISoftware<ITiltEventOutputHandler>
    {
        private readonly ITiltEventInputHandler inputHandler;

        public IDisconnection Connect(ITiltEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var centerHasPulled = handler.Center.HasPulled.Connect(inputHandler.Center.HasPulled);
            var centerIsPulled = handler.Center.IsPulled.Connect(inputHandler.Center.IsPulled);
            var centerHasReleased = handler.Center.HasReleased.Connect(inputHandler.Center.HasReleased);
            var centerIsReleased = handler.Center.IsReleased.Connect(inputHandler.Center.IsReleased);

            var leftHasPulled = handler.Left.HasPulled.Connect(inputHandler.Left.HasPulled);
            var leftIsPulled = handler.Left.IsPulled.Connect(inputHandler.Left.IsPulled);
            var leftHasReleased = handler.Left.HasReleased.Connect(inputHandler.Left.HasReleased);
            var leftIsReleased = handler.Left.IsReleased.Connect(inputHandler.Left.IsReleased);

            var rightHasPulled = handler.Right.HasPulled.Connect(inputHandler.Right.HasPulled);
            var rightIsPulled = handler.Right.IsPulled.Connect(inputHandler.Right.IsPulled);
            var rightHasReleased = handler.Right.HasReleased.Connect(inputHandler.Right.HasReleased);
            var rightIsReleased = handler.Right.IsReleased.Connect(inputHandler.Right.IsReleased);

            var upHasPulled = handler.Up.HasPulled.Connect(inputHandler.Up.HasPulled);
            var upIsPulled = handler.Up.IsPulled.Connect(inputHandler.Up.IsPulled);
            var upHasReleased = handler.Up.HasReleased.Connect(inputHandler.Up.HasReleased);
            var upIsReleased = handler.Up.IsReleased.Connect(inputHandler.Up.IsReleased);

            var downHasPulled = handler.Down.HasPulled.Connect(inputHandler.Down.HasPulled);
            var downIsPulled = handler.Down.IsPulled.Connect(inputHandler.Down.IsPulled);
            var downHasReleased = handler.Down.HasReleased.Connect(inputHandler.Down.HasReleased);
            var downIsReleased = handler.Down.IsReleased.Connect(inputHandler.Down.IsReleased);

            return new Disconnection(() =>
            {
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
