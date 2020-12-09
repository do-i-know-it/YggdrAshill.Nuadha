using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerDevice :
        IHardware<IPoseTrackerHardwareHandler>,
        IDisconnection,
        IIgnitor
    {
        private readonly IPoseTrackerConfiguration configuration;

        public PoseTrackerDevice(IPoseTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        public IDisconnection Connect(IPoseTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var position = configuration.Position.Connect(handler.Position);

            var rotation = configuration.Rotation.Connect(handler.Rotation);

            return new Disconnection(() =>
            {
                position.Disconnect();

                rotation.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            configuration.Position.Disconnect();

            configuration.Rotation.Disconnect();
        }

        #endregion

        #region Ignitor

        public IEmission Ignite()
        {
            var position = configuration.Position.Ignite();

            var rotation = configuration.Rotation.Ignite();

            return new Emission(() =>
            {
                position.Emit();

                rotation.Emit();
            });
        }

        #endregion
    }
}
