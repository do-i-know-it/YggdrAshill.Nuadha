using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDevice :
        IInputDevice<IButtonSoftware>
    {
        private readonly IButtonConfiguration configuration;

        private readonly ButtonModule module = new ButtonModule();

        public ButtonDevice(IButtonConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IDevice

        private IButtonHardware Hardware => module;
        public IDisconnection Connect(IButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var touch = Hardware.Touch.Connect(software.Touch);

            var push = Hardware.Push.Connect(software.Push);

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
            module.Disconnect();
        }

        #endregion

        #region Ignition

        private IButtonSoftware Software => module;
        public IEmission Ignite()
        {
            var touch = configuration.Touch.Produce(Software.Touch);

            var push = configuration.Push.Produce(Software.Push);

            return new Emission(() =>
            {
                touch.Emit();

                push.Emit();

            });
        }

        #endregion
    }
}
