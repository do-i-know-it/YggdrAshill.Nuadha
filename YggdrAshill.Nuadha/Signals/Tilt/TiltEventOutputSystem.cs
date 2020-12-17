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

            var leftHasEnabled = handler.Left.HasEnabled.Connect(inputHandler.Left.HasEnabled);
            var leftIsEnabled = handler.Left.IsEnabled.Connect(inputHandler.Left.IsEnabled);
            var leftHasDisabled = handler.Left.HasDisabled.Connect(inputHandler.Left.HasDisabled);
            var leftIsDisabled = handler.Left.IsDisabled.Connect(inputHandler.Left.IsDisabled);

            var rightHasEnabled = handler.Right.HasEnabled.Connect(inputHandler.Right.HasEnabled);
            var rightIsEnabled = handler.Right.IsEnabled.Connect(inputHandler.Right.IsEnabled);
            var rightHasDisabled = handler.Right.HasDisabled.Connect(inputHandler.Right.HasDisabled);
            var rightIsDisabled = handler.Right.IsDisabled.Connect(inputHandler.Right.IsDisabled);

            var forwardHasEnabled = handler.Forward.HasEnabled.Connect(inputHandler.Forward.HasEnabled);
            var forwardIsEnabled = handler.Forward.IsEnabled.Connect(inputHandler.Forward.IsEnabled);
            var forwardHasDisabled = handler.Forward.HasDisabled.Connect(inputHandler.Forward.HasDisabled);
            var forwardIsDisabled = handler.Forward.IsDisabled.Connect(inputHandler.Forward.IsDisabled);

            var backwardHasEnabled = handler.Backward.HasEnabled.Connect(inputHandler.Backward.HasEnabled);
            var backwardIsEnabled = handler.Backward.IsEnabled.Connect(inputHandler.Backward.IsEnabled);
            var backwardHasDisabled = handler.Backward.HasDisabled.Connect(inputHandler.Backward.HasDisabled);
            var backwardIsDisabled = handler.Backward.IsDisabled.Connect(inputHandler.Backward.IsDisabled);

            return new Disconnection(() =>
            {
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
