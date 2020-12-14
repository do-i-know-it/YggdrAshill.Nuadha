using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class BlinkEventOutputSystem :
        ISoftware<IBlinkEventOutputHandler>
    {
        private readonly IBlinkEventInputHandler inputHandler;

        public BlinkEventOutputSystem(IBlinkEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(IBlinkEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasOpened = handler.HasOpened.Connect(inputHandler.HasOpened);
            
            var isOpened = handler.IsOpened.Connect(inputHandler.IsOpened);
            
            var hasClosed = handler.HasClosed.Connect(inputHandler.HasClosed);
            
            var isClosed = handler.IsClosed.Connect(inputHandler.IsClosed);

            return new Disconnection(() =>
            {
                hasOpened.Disconnect();
                
                isOpened.Disconnect();
                
                hasClosed.Disconnect();
                
                isClosed.Disconnect();
            });
        }
    }
}
