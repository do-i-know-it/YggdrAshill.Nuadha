using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerEventOutputSystem :
        ISoftware<IEyeTrackerEventOutputHandler>
    {
        private readonly IEyeTrackerEventInputHandler inputHandler;

        public EyeTrackerEventOutputSystem(IEyeTrackerEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(IEyeTrackerEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var pupilHasEnabled = handler.Pupil.HasEnabled.Connect(inputHandler.Pupil.HasEnabled);
            var pupilIsEnabled = handler.Pupil.IsEnabled.Connect(inputHandler.Pupil.IsEnabled);
            var pupilHasDisabled = handler.Pupil.HasDisabled.Connect(inputHandler.Pupil.HasDisabled);
            var pupilIsDisabled = handler.Pupil.IsDisabled.Connect(inputHandler.Pupil.IsDisabled);

            var blinkHasEnabled = handler.Blink.HasEnabled.Connect(inputHandler.Blink.HasEnabled);
            var blinkIsEnabled = handler.Blink.IsEnabled.Connect(inputHandler.Blink.IsEnabled);
            var blinkHasDisabled = handler.Blink.HasDisabled.Connect(inputHandler.Blink.HasDisabled);
            var blinkIsDisabled = handler.Blink.IsDisabled.Connect(inputHandler.Blink.IsDisabled);

            return new Disconnection(() =>
            {
                pupilHasEnabled.Disconnect();
                pupilIsEnabled.Disconnect();
                pupilHasDisabled.Disconnect();
                pupilIsDisabled.Disconnect();

                blinkHasEnabled.Disconnect();
                blinkIsEnabled.Disconnect();
                blinkHasDisabled.Disconnect();
                blinkIsDisabled.Disconnect();
            });
        }
    }
}
