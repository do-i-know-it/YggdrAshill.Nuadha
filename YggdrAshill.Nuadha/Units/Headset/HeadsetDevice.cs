using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetDevice :
        IInputDevice<IHeadsetHardwareHandler>
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

        #region IHardware

        private IHeadsetSoftwareHandler SoftwareHandler => module;
        public IDisconnection Connect(IHeadsetHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var direction = SoftwareHandler.Direction.Connect(handler.Direction);

            var position = SoftwareHandler.PoseTracker.Position.Connect(handler.PoseTracker.Position);
            var rotation = SoftwareHandler.PoseTracker.Rotation.Connect(handler.PoseTracker.Rotation);

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

        private IHeadsetHardwareHandler HardwareHandler => module;
        public IEmission Ignite()
        {
            var direction = configuration.Direction.Produce(HardwareHandler.Direction);

            var position = configuration.PoseTracker.Position.Produce(HardwareHandler.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Produce(HardwareHandler.PoseTracker.Rotation);

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
