using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDevice :
        IInputDevice<IButtonHardwareHandler>
    {
        private readonly IButtonConfiguration configuration;

        public ButtonDevice(IButtonConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        public IDisconnection Connect(IButtonHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = configuration.Touch.Connect(handler.Touch);

            var push = configuration.Push.Connect(handler.Push);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                push.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            configuration.Touch.Disconnect();

            configuration.Push.Disconnect();
        }

        #endregion

        #region Ignitor

        public IEmission Ignite()
        {
            var touch = configuration.Touch.Ignite();

            var push = configuration.Push.Ignite();

            return new Emission(() =>
            {
                touch.Emit();

                push.Emit();

            });
        }

        #endregion
    }
}
