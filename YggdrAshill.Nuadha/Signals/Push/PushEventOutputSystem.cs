using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PushEventOutputSystem :
        ISoftware<IPushEventOutputHandler>
    {
        private readonly IPushEventInputHandler inputHandler;

        public PushEventOutputSystem(IPushEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(IPushEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasPushed = handler.HasPushed.Connect(inputHandler.HasPushed);

            var isPushed = handler.IsPushed.Connect(inputHandler.IsPushed);

            var hasReleased = handler.HasReleased.Connect(inputHandler.HasReleased);

            var isReleased = handler.IsReleased.Connect(inputHandler.IsReleased);

            return new Disconnection(() =>
            {
                hasPushed.Disconnect();

                isPushed.Disconnect();

                hasReleased.Disconnect();

                isReleased.Disconnect();
            });
        }
    }
}
