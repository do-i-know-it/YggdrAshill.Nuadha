using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDevice :
        IInputDevice<ITriggerHardwareHandler>
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

        private ITriggerSoftwareHandler SoftwareHandler => module;
        public IDisconnection Connect(ITriggerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = SoftwareHandler.Touch.Connect(handler.Touch);

            var pull = SoftwareHandler.Pull.Connect(handler.Pull);

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

        private ITriggerHardwareHandler HardwareHandler => module;
        public IEmission Ignite()
        {
            var touch = configuration.Touch.Produce(HardwareHandler.Touch);

            var pull = configuration.Pull.Produce(HardwareHandler.Pull);

            return new Emission(() =>
            {
                touch.Emit();

                pull.Emit();

            });
        }

        #endregion
    }
}
