using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDevice :
        IHardware<ITriggerHardwareHandler>,
        IDisconnection,
        IIgnitor
    {
        private readonly ITriggerConfiguration configuration;

        public TriggerDevice(ITriggerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        public IDisconnection Connect(ITriggerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = configuration.Touch.Connect(handler.Touch);

            var pull = configuration.Pull.Connect(handler.Pull);

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
            configuration.Touch.Disconnect();

            configuration.Pull.Disconnect();
        }

        #endregion

        #region Ignitor

        public IEmission Ignite()
        {
            var touch = configuration.Touch.Ignite();

            var pull = configuration.Pull.Ignite();

            return new Emission(() =>
            {
                touch.Emit();

                pull.Emit();

            });
        }

        #endregion
    }
}
