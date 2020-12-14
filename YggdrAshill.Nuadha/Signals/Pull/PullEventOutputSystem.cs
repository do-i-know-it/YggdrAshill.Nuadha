using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullEventOutputSystem :
        ISoftware<IPullEventOutputHandler>
    {
        private readonly IPullEventInputHandler inputHandler;

        public PullEventOutputSystem(IPullEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(IPullEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasPulled = handler.HasPulled.Connect(inputHandler.HasPulled);

            var isPulled = handler.IsPulled.Connect(inputHandler.IsPulled);

            var hasReleased = handler.HasReleased.Connect(inputHandler.HasReleased);

            var isReleased = handler.IsReleased.Connect(inputHandler.IsReleased);

            return new Disconnection(() =>
            {
                hasPulled.Disconnect();

                isPulled.Disconnect();

                hasReleased.Disconnect();

                isReleased.Disconnect();
            });
        }
    }
}
