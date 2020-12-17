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

            var touchHasEnabled = handler.Touch.HasEnabled.Connect(inputHandler.Touch.HasEnabled);
            var touchIsEnabled = handler.Touch.IsEnabled.Connect(inputHandler.Touch.IsEnabled);
            var touchHasDisabled = handler.Touch.HasDisabled.Connect(inputHandler.Touch.HasDisabled);
            var touchIsDisabled = handler.Touch.IsDisabled.Connect(inputHandler.Touch.IsDisabled);

            var pullHasEnabled = handler.Pull.HasEnabled.Connect(inputHandler.Pull.HasEnabled);
            var pullIsEnabled = handler.Pull.IsEnabled.Connect(inputHandler.Pull.IsEnabled);
            var pullHasDisabled = handler.Pull.HasDisabled.Connect(inputHandler.Pull.HasDisabled);
            var pullIsDisabled = handler.Pull.IsDisabled.Connect(inputHandler.Pull.IsDisabled);

            return new Disconnection(() =>
            {
                touchHasEnabled.Disconnect();
                touchIsEnabled.Disconnect();
                touchHasDisabled.Disconnect();
                touchIsDisabled.Disconnect();

                pullHasEnabled.Disconnect();
                pullIsEnabled.Disconnect();
                pullHasDisabled.Disconnect();
                pullIsDisabled.Disconnect();
            });
        }
    }
}
