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
        IIgnition
    {
        private readonly IPoseTrackerConfiguration configuration;

        private readonly PoseTrackerModule module = new PoseTrackerModule();

        public PoseTrackerDevice(IPoseTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        private IPoseTrackerSoftwareHandler SoftwareHandler => module;

        public IDisconnection Connect(IPoseTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var position = SoftwareHandler.Position.Connect(handler.Position);

            var rotation = SoftwareHandler.Rotation.Connect(handler.Rotation);

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
            module.Disconnect();
        }

        #endregion

        #region Ignition

        private IPoseTrackerHardwareHandler HardwareHandler => module;

        public IEmission Ignite()
        {
            var position = configuration.Position.Connect(HardwareHandler.Position);

            var rotation = configuration.Rotation.Connect(HardwareHandler.Rotation);

            return new Emission(() =>
            {
                position.Emit();

                rotation.Emit();
            });
        }

        #endregion
    }
}
