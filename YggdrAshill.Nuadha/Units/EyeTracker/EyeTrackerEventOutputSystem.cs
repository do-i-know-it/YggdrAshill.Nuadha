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

            var pupilHasOpened = handler.Pupil.HasOpened.Connect(inputHandler.Pupil.HasOpened);
            var pupilIsOpened = handler.Pupil.IsOpened.Connect(inputHandler.Pupil.IsOpened);
            var pupilHasClosed = handler.Pupil.HasClosed.Connect(inputHandler.Pupil.HasClosed);
            var pupilIsClosed = handler.Pupil.IsClosed.Connect(inputHandler.Pupil.IsClosed);

            var blinkHasOpened = handler.Blink.HasOpened.Connect(inputHandler.Blink.HasOpened);
            var blinkIsOpened = handler.Blink.IsOpened.Connect(inputHandler.Blink.IsOpened);
            var blinkHasClosed = handler.Blink.HasClosed.Connect(inputHandler.Blink.HasClosed);
            var blinkIsClosed = handler.Blink.IsClosed.Connect(inputHandler.Blink.IsClosed);

            return new Disconnection(() =>
            {
                pupilHasOpened.Disconnect();
                pupilIsOpened.Disconnect();
                pupilHasClosed.Disconnect();
                pupilIsClosed.Disconnect();

                blinkHasOpened.Disconnect();
                blinkIsOpened.Disconnect();
                blinkHasClosed.Disconnect();
                blinkIsClosed.Disconnect();
            });
        }
    }
}
