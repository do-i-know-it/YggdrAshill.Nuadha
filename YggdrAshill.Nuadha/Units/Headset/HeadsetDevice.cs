using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetDevice :
        IInputDevice<IHeadsetSoftware>
    {
        private readonly IHeadsetConfiguration configuration;

        private readonly HeadsetModule module = new HeadsetModule();

        public HeadsetDevice(IHeadsetConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IDevice

        private IHeadsetHardware Hardware => module;
        public IDisconnection Connect(IHeadsetSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var direction = Hardware.Direction.Connect(software.Direction);

            var position = Hardware.PoseTracker.Position.Connect(software.PoseTracker.Position);
            var rotation = Hardware.PoseTracker.Rotation.Connect(software.PoseTracker.Rotation);

            return new Disconnection(() =>
            {
                direction.Disconnect();

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

        private IHeadsetSoftware Software => module;
        public IEmission Ignite()
        {
            var direction = configuration.Direction.Produce(Software.Direction);

            var position = configuration.PoseTracker.Position.Produce(Software.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Produce(Software.PoseTracker.Rotation);

            return new Emission(() =>
            {
                direction.Emit();

                position.Emit();
                rotation.Emit();
            });
        }

        #endregion
    }
}
