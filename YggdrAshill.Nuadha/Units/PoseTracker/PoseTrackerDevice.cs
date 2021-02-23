using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerDevice :
        IInputHardware<IPoseTrackerSystem>
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

        private IPoseTrackerDevice Device => module;
        public IDisconnection Connect(IPoseTrackerSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var position = Device.Position.Connect(system.Position);

            var rotation = Device.Rotation.Connect(system.Rotation);

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

        private IPoseTrackerSystem System => module;
        public IEmission Ignite()
        {
            var position = configuration.Position.Produce(System.Position);

            var rotation = configuration.Rotation.Produce(System.Rotation);

            return new Emission(() =>
            {
                position.Emit();

                rotation.Emit();
            });
        }

        #endregion
    }
}
