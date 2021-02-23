using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDevice :
        IInputHardware<IButtonSystem>
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

        private IButtonDevice Device => module;
        public IDisconnection Connect(IButtonSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var touch = Device.Touch.Connect(system.Touch);

            var push = Device.Push.Connect(system.Push);

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

        private IButtonSystem System => module;
        public IEmission Ignite()
        {
            var touch = configuration.Touch.Produce(System.Touch);

            var push = configuration.Push.Produce(System.Push);

            return new Emission(() =>
            {
                touch.Emit();

                push.Emit();

            });
        }

        #endregion
    }
}
