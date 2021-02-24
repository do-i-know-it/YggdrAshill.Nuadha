using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerDevice :
        IInputDevice<IThreePointTrackerSoftware>
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

        #region IDevice

        private IThreePointTrackerHardware Hardware => module;
        public IDisconnection Connect(IThreePointTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            // Head
            var headPosition = Hardware.Head.Position.Connect(software.Head.Position);
            var headRotation = Hardware.Head.Rotation.Connect(software.Head.Rotation);

            // Left hand
            var leftHandPosition = Hardware.LeftHand.Position.Connect(software.LeftHand.Position);
            var leftHandRotation = Hardware.LeftHand.Rotation.Connect(software.LeftHand.Rotation);

            // Right hand
            var rightHandPosition = Hardware.RightHand.Position.Connect(software.RightHand.Position);
            var rightHandRotation = Hardware.RightHand.Rotation.Connect(software.RightHand.Rotation);

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

        private IThreePointTrackerSoftware Software => module;
        public IEmission Ignite()
        {
            // Head
            var headPosition = configuration.Head.Position.Produce(Software.Head.Position);
            var headRotation = configuration.Head.Rotation.Produce(Software.Head.Rotation);

            // Left hand
            var leftHandPosition = configuration.LeftHand.Position.Produce(Software.LeftHand.Position);
            var leftHandRotation = configuration.LeftHand.Rotation.Produce(Software.LeftHand.Rotation);

            // Right hand
            var rightHandPosition = configuration.RightHand.Position.Produce(Software.RightHand.Position);
            var rightHandRotation = configuration.RightHand.Rotation.Produce(Software.RightHand.Rotation);

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
