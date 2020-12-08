using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDevice :
        IHardware<IButtonHardwareHandler>,
        IDisconnection,
        IIgnition
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

        #region IHardware

        private IButtonSoftwareHandler SoftwareHandler => module;

        public IDisconnection Connect(IButtonHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = SoftwareHandler.Touch.Connect(handler.Touch);

            var push = SoftwareHandler.Push.Connect(handler.Push);

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

        private IButtonHardwareHandler HardwareHandler => module;

        public IEmission Ignite()
        {
            var touch = configuration.Touch.Connect(HardwareHandler.Touch);

            var push = configuration.Push.Connect(HardwareHandler.Push);

            return new Emission(() =>
            {
                touch.Emit();

                push.Emit();

            });
        }

        #endregion
    }
}
