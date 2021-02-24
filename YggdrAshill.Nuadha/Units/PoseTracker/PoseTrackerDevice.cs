using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerDevice :
        IInputDevice<IPoseTrackerSoftware>
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

        #region IDevice

        private IPoseTrackerHardware Hardware => module;
        public IDisconnection Connect(IPoseTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var position = Hardware.Position.Connect(software.Position);

            var rotation = Hardware.Rotation.Connect(software.Rotation);

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

        private IPoseTrackerSoftware Software => module;
        public IEmission Ignite()
        {
            var position = configuration.Position.Produce(Software.Position);

            var rotation = configuration.Rotation.Produce(Software.Rotation);

            return new Emission(() =>
            {
                position.Emit();

                rotation.Emit();
            });
        }

        #endregion
    }
}
