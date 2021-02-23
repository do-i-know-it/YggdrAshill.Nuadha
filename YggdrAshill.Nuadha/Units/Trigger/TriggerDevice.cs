using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDevice :
        IInputHardware<ITriggerSystem>
    {
        private readonly ITriggerConfiguration configuration;

        private readonly TriggerModule module = new TriggerModule();

        public TriggerDevice(ITriggerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        private ITriggerDevice Device => module;
        public IDisconnection Connect(ITriggerSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var touch = Device.Touch.Connect(system.Touch);

            var pull = Device.Pull.Connect(system.Pull);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                pull.Disconnect();
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

        private ITriggerSystem System => module;
        public IEmission Ignite()
        {
            var touch = configuration.Touch.Produce(System.Touch);

            var pull = configuration.Pull.Produce(System.Pull);

            return new Emission(() =>
            {
                touch.Emit();

                pull.Emit();

            });
        }

        #endregion
    }
}
