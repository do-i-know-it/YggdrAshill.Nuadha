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

        public TiltEventOutputSystem(ITiltEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

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

            var forwardHasPulled = handler.Forward.HasPulled.Connect(inputHandler.Forward.HasPulled);
            var forwardIsPulled = handler.Forward.IsPulled.Connect(inputHandler.Forward.IsPulled);
            var forwardHasReleased = handler.Forward.HasReleased.Connect(inputHandler.Forward.HasReleased);
            var forwardIsReleased = handler.Forward.IsReleased.Connect(inputHandler.Forward.IsReleased);

            var backwardHasPulled = handler.Backward.HasPulled.Connect(inputHandler.Backward.HasPulled);
            var backwardIsPulled = handler.Backward.IsPulled.Connect(inputHandler.Backward.IsPulled);
            var backwardHasReleased = handler.Backward.HasReleased.Connect(inputHandler.Backward.HasReleased);
            var backwardIsReleased = handler.Backward.IsReleased.Connect(inputHandler.Backward.IsReleased);

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
