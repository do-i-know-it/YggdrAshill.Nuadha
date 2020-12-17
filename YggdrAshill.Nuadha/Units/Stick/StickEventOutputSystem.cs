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

            var touchHasEnabled = handler.Touch.HasEnabled.Connect(inputHandler.Touch.HasEnabled);
            var touchIsEnabled = handler.Touch.IsEnabled.Connect(inputHandler.Touch.IsEnabled);
            var touchHasDisabled = handler.Touch.HasDisabled.Connect(inputHandler.Touch.HasDisabled);
            var touchIsDisabled = handler.Touch.IsDisabled.Connect(inputHandler.Touch.IsDisabled);

            var pushHasEnabled = handler.Push.HasEnabled.Connect(inputHandler.Push.HasEnabled);
            var pushIsEnabled = handler.Push.IsEnabled.Connect(inputHandler.Push.IsEnabled);
            var pushHasDisabled = handler.Push.HasDisabled.Connect(inputHandler.Push.HasDisabled);
            var pushIsDisabled = handler.Push.IsDisabled.Connect(inputHandler.Push.IsDisabled);

            var leftHasEnabled = handler.Tilt.Left.HasEnabled.Connect(inputHandler.Tilt.Left.HasEnabled);
            var leftIsEnabled = handler.Tilt.Left.IsEnabled.Connect(inputHandler.Tilt.Left.IsEnabled);
            var leftHasDisabled = handler.Tilt.Left.HasDisabled.Connect(inputHandler.Tilt.Left.HasDisabled);
            var leftIsDisabled = handler.Tilt.Left.IsDisabled.Connect(inputHandler.Tilt.Left.IsDisabled);

            var rightHasEnabled = handler.Tilt.Right.HasEnabled.Connect(inputHandler.Tilt.Right.HasEnabled);
            var rightIsEnabled = handler.Tilt.Right.IsEnabled.Connect(inputHandler.Tilt.Right.IsEnabled);
            var rightHasDisabled = handler.Tilt.Right.HasDisabled.Connect(inputHandler.Tilt.Right.HasDisabled);
            var rightIsDisabled = handler.Tilt.Right.IsDisabled.Connect(inputHandler.Tilt.Right.IsDisabled);

            var forwardHasEnabled = handler.Tilt.Forward.HasEnabled.Connect(inputHandler.Tilt.Forward.HasEnabled);
            var forwardIsEnabled = handler.Tilt.Forward.IsEnabled.Connect(inputHandler.Tilt.Forward.IsEnabled);
            var forwardHasDisabled = handler.Tilt.Forward.HasDisabled.Connect(inputHandler.Tilt.Forward.HasDisabled);
            var forwardIsDisabled = handler.Tilt.Forward.IsDisabled.Connect(inputHandler.Tilt.Forward.IsDisabled);

            var backwardHasEnabled = handler.Tilt.Backward.HasEnabled.Connect(inputHandler.Tilt.Backward.HasEnabled);
            var backwardIsEnabled = handler.Tilt.Backward.IsEnabled.Connect(inputHandler.Tilt.Backward.IsEnabled);
            var backwardHasDisabled = handler.Tilt.Backward.HasDisabled.Connect(inputHandler.Tilt.Backward.HasDisabled);
            var backwardIsDisabled = handler.Tilt.Backward.IsDisabled.Connect(inputHandler.Tilt.Backward.IsDisabled);

            return new Disconnection(() =>
            {
                touchHasEnabled.Disconnect();
                touchIsEnabled.Disconnect();
                touchHasDisabled.Disconnect();
                touchIsDisabled.Disconnect();

                pushHasEnabled.Disconnect();
                pushIsEnabled.Disconnect();
                pushHasDisabled.Disconnect();
                pushIsDisabled.Disconnect();

                leftHasEnabled.Disconnect();
                leftIsEnabled.Disconnect();
                leftHasDisabled.Disconnect();
                leftIsDisabled.Disconnect();

                rightHasEnabled.Disconnect();
                rightIsEnabled.Disconnect();
                rightHasDisabled.Disconnect();
                rightIsDisabled.Disconnect();

                forwardHasEnabled.Disconnect();
                forwardIsEnabled.Disconnect();
                forwardHasDisabled.Disconnect();
                forwardIsDisabled.Disconnect();

                backwardHasEnabled.Disconnect();
                backwardIsEnabled.Disconnect();
                backwardHasDisabled.Disconnect();
                backwardIsDisabled.Disconnect();
            });
        }
    }
}
