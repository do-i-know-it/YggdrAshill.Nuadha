using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulseEventOutputSystem :
        ISoftware<IPulseEventOutputHandler>
    {
        private readonly IPulseEventInputHandler inputHandler;

        public PulseEventOutputSystem(IPulseEventInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this.inputHandler = inputHandler;
        }

        public IDisconnection Connect(IPulseEventOutputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasEnabled = handler.HasEnabled.Connect(inputHandler.HasEnabled);
            
            var isEnabled = handler.IsEnabled.Connect(inputHandler.IsEnabled);
            
            var hasDisabled = handler.HasDisabled.Connect(inputHandler.HasDisabled);
            
            var isDisabled = handler.IsDisabled.Connect(inputHandler.IsDisabled);

            return new Disconnection(() =>
            {
                hasEnabled.Disconnect();
                
                isEnabled.Disconnect();
                
                hasDisabled.Disconnect();
                
                isDisabled.Disconnect();
            });
        }
    }
}
