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

            var touchHasEnabled = handler.Touch.HasEnabled.Connect(inputHandler.Touch.HasEnabled);
            var touchIsEnabled = handler.Touch.IsEnabled.Connect(inputHandler.Touch.IsEnabled);
            var touchHasDisabled = handler.Touch.HasDisabled.Connect(inputHandler.Touch.HasDisabled);
            var touchIsDisabled = handler.Touch.IsDisabled.Connect(inputHandler.Touch.IsDisabled);

            var pushHasEnabled = handler.Push.HasEnabled.Connect(inputHandler.Push.HasEnabled);
            var pushIsEnabled = handler.Push.IsEnabled.Connect(inputHandler.Push.IsEnabled);
            var pushHasDisabled = handler.Push.HasDisabled.Connect(inputHandler.Push.HasDisabled);
            var pushIsDisabled = handler.Push.IsDisabled.Connect(inputHandler.Push.IsDisabled);

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
            });
        }
    }
}
