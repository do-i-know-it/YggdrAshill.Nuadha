using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerDevice :
        IInputHardware<IThreePointTrackerSystem>
    {
        private readonly IThreePointTrackerConfiguration configuration;

        private readonly ThreePointTrackerModule module = new ThreePointTrackerModule();

        public ThreePointTrackerDevice(IThreePointTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        private IThreePointTrackerDevice Device => module;
        public IDisconnection Connect(IThreePointTrackerSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            // Head
            var headPosition = Device.Head.Position.Connect(system.Head.Position);
            var headRotation = Device.Head.Rotation.Connect(system.Head.Rotation);

            // Left hand
            var leftHandPosition = Device.LeftHand.Position.Connect(system.LeftHand.Position);
            var leftHandRotation = Device.LeftHand.Rotation.Connect(system.LeftHand.Rotation);

            // Right hand
            var rightHandPosition = Device.RightHand.Position.Connect(system.RightHand.Position);
            var rightHandRotation = Device.RightHand.Rotation.Connect(system.RightHand.Rotation);

            return new Disconnection(() =>
            {
                // Head
                headPosition.Disconnect();
                headRotation.Disconnect();

                // Left hand
                leftHandPosition.Disconnect();
                leftHandRotation.Disconnect();

                // Right hand
                rightHandPosition.Disconnect();
                rightHandRotation.Disconnect();
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

        private IThreePointTrackerSystem System => module;
        public IEmission Ignite()
        {
            // Head
            var headPosition = configuration.Head.Position.Produce(System.Head.Position);
            var headRotation = configuration.Head.Rotation.Produce(System.Head.Rotation);

            // Left hand
            var leftHandPosition = configuration.LeftHand.Position.Produce(System.LeftHand.Position);
            var leftHandRotation = configuration.LeftHand.Rotation.Produce(System.LeftHand.Rotation);

            // Right hand
            var rightHandPosition = configuration.RightHand.Position.Produce(System.RightHand.Position);
            var rightHandRotation = configuration.RightHand.Rotation.Produce(System.RightHand.Rotation);

            return new Emission(() =>
            {
                // Head
                headPosition.Emit();
                headRotation.Emit();

                // Left hand
                leftHandPosition.Emit();
                leftHandRotation.Emit();

                // Right hand
                rightHandPosition.Emit();
                rightHandRotation.Emit();
            });
        }

        #endregion
    }
}
