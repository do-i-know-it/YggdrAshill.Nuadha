using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDevice :
        IInputDevice<ITriggerSoftware>
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

        #region IDevice

        private ITriggerHardware Hardware => module;
        public IDisconnection Connect(ITriggerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var touch = Hardware.Touch.Connect(software.Touch);

            var pull = Hardware.Pull.Connect(software.Pull);

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

        private ITriggerSoftware Software => module;
        public IEmission Ignite()
        {
            var touch = configuration.Touch.Produce(Software.Touch);

            var pull = configuration.Pull.Produce(Software.Pull);

            return new Emission(() =>
            {
                touch.Emit();

                pull.Emit();

            });
        }

        #endregion
    }
}
