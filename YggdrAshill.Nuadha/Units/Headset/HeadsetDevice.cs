using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetDevice :
        IInputHardware<IHeadsetSystem>
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

        private IHeadsetDevice Device => module;
        public IDisconnection Connect(IHeadsetSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var direction = Device.Direction.Connect(system.Direction);

            var position = Device.PoseTracker.Position.Connect(system.PoseTracker.Position);
            var rotation = Device.PoseTracker.Rotation.Connect(system.PoseTracker.Rotation);

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

        private IHeadsetSystem System => module;
        public IEmission Ignite()
        {
            var direction = configuration.Direction.Produce(System.Direction);

            var position = configuration.PoseTracker.Position.Produce(System.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Produce(System.PoseTracker.Rotation);

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
