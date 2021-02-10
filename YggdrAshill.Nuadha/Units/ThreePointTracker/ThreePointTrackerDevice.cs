using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerDevice :
        IInputDevice<IThreePointTrackerHardwareHandler>
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

        private IThreePointTrackerSoftwareHandler SoftwareHandler => module;
        public IDisconnection Connect(IThreePointTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            // Origin
            var originPosition = SoftwareHandler.Origin.Position.Connect(handler.Origin.Position);
            var originRotation = SoftwareHandler.Origin.Rotation.Connect(handler.Origin.Rotation);

            // Head

            var headPosition = SoftwareHandler.Head.Position.Connect(handler.Head.Position);
            var headRotation = SoftwareHandler.Head.Rotation.Connect(handler.Head.Rotation);

            // Left hand
            var leftHandPosition = SoftwareHandler.LeftHand.Position.Connect(handler.LeftHand.Position);
            var leftHandRotation = SoftwareHandler.LeftHand.Rotation.Connect(handler.LeftHand.Rotation);

            // Right hand
            var rightHandPosition = SoftwareHandler.RightHand.Position.Connect(handler.RightHand.Position);
            var rightHandRotation = SoftwareHandler.RightHand.Rotation.Connect(handler.RightHand.Rotation);

            return new Disconnection(() =>
            {
                // Origin
                originPosition.Disconnect();
                originRotation.Disconnect();

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

        private IThreePointTrackerHardwareHandler HardwareHandler => module;
        public IEmission Ignite()
        {

            // Origin
            var originPosition = configuration.Origin.Position.Produce(HardwareHandler.Origin.Position);
            var originRotation = configuration.Origin.Rotation.Produce(HardwareHandler.Origin.Rotation);

            // Head
            var headPosition = configuration.Head.Position.Produce(HardwareHandler.Head.Position);
            var headRotation = configuration.Head.Rotation.Produce(HardwareHandler.Head.Rotation);

            // Left hand
            var leftHandPosition = configuration.LeftHand.Position.Produce(HardwareHandler.LeftHand.Position);
            var leftHandRotation = configuration.LeftHand.Rotation.Produce(HardwareHandler.LeftHand.Rotation);

            // Right hand
            var rightHandPosition = configuration.RightHand.Position.Produce(HardwareHandler.RightHand.Position);
            var rightHandRotation = configuration.RightHand.Rotation.Produce(HardwareHandler.RightHand.Rotation);

            return new Emission(() =>
            {
                // Origin
                originPosition.Emit();
                originRotation.Emit();

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
