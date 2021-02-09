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

            var position = SoftwareHandler.PoseTracker.Position.Connect(handler.PoseTracker.Position);
            var rotation = SoftwareHandler.PoseTracker.Rotation.Connect(handler.PoseTracker.Rotation);

            // Head
            var headDirection = SoftwareHandler.Head.Direction.Connect(handler.Head.Direction);

            var headPosition = SoftwareHandler.Head.PoseTracker.Position.Connect(handler.Head.PoseTracker.Position);
            var headRotation = SoftwareHandler.Head.PoseTracker.Rotation.Connect(handler.Head.PoseTracker.Rotation);

            var headLeftEyePupil = SoftwareHandler.Head.LeftEye.Pupil.Connect(handler.Head.LeftEye.Pupil);
            var headLeftEyeBlink = SoftwareHandler.Head.LeftEye.Blink.Connect(handler.Head.LeftEye.Blink);

            var headRightEyePupil = SoftwareHandler.Head.RightEye.Pupil.Connect(handler.Head.RightEye.Pupil);
            var headRightEyeBlink = SoftwareHandler.Head.RightEye.Blink.Connect(handler.Head.RightEye.Blink);

            // Left hand
            var leftHandPosition = SoftwareHandler.LeftHand.PoseTracker.Position.Connect(handler.LeftHand.PoseTracker.Position);
            var leftHandRotation = SoftwareHandler.LeftHand.PoseTracker.Rotation.Connect(handler.LeftHand.PoseTracker.Rotation);

            var leftHandThumbStickTouch = SoftwareHandler.LeftHand.ThumbStick.Touch.Connect(handler.LeftHand.ThumbStick.Touch);
            var leftHandThumbStickPush = SoftwareHandler.LeftHand.ThumbStick.Push.Connect(handler.LeftHand.ThumbStick.Push);
            var leftHandThumbStickTilt = SoftwareHandler.LeftHand.ThumbStick.Tilt.Connect(handler.LeftHand.ThumbStick.Tilt);

            var leftHandFingerTriggerTouch = SoftwareHandler.LeftHand.FingerTrigger.Touch.Connect(handler.LeftHand.FingerTrigger.Touch);
            var leftHandFingerTriggerPull = SoftwareHandler.LeftHand.FingerTrigger.Pull.Connect(handler.LeftHand.FingerTrigger.Pull);

            var leftHandHandTriggerTouch = SoftwareHandler.LeftHand.HandTrigger.Touch.Connect(handler.LeftHand.HandTrigger.Touch);
            var leftHandHandTriggerPull = SoftwareHandler.LeftHand.HandTrigger.Pull.Connect(handler.LeftHand.HandTrigger.Pull);

            // Right hand
            var rightHandPosition = SoftwareHandler.RightHand.PoseTracker.Position.Connect(handler.RightHand.PoseTracker.Position);
            var rightHandRotation = SoftwareHandler.RightHand.PoseTracker.Rotation.Connect(handler.RightHand.PoseTracker.Rotation);

            var rightHandThumbStickTouch = SoftwareHandler.RightHand.ThumbStick.Touch.Connect(handler.RightHand.ThumbStick.Touch);
            var rightHandThumbStickPush = SoftwareHandler.RightHand.ThumbStick.Push.Connect(handler.RightHand.ThumbStick.Push);
            var rightHandThumbStickTilt = SoftwareHandler.RightHand.ThumbStick.Tilt.Connect(handler.RightHand.ThumbStick.Tilt);

            var rightHandFingerTriggerTouch = SoftwareHandler.RightHand.FingerTrigger.Touch.Connect(handler.RightHand.FingerTrigger.Touch);
            var rightHandFingerTriggerPull = SoftwareHandler.RightHand.FingerTrigger.Pull.Connect(handler.RightHand.FingerTrigger.Pull);

            var rightHandHandTriggerTouch = SoftwareHandler.RightHand.HandTrigger.Touch.Connect(handler.RightHand.HandTrigger.Touch);
            var rightHandHandTriggerPull = SoftwareHandler.RightHand.HandTrigger.Pull.Connect(handler.RightHand.HandTrigger.Pull);

            return new Disconnection(() =>
            {
                position.Disconnect();
                rotation.Disconnect();

                // Head
                headDirection.Disconnect();

                headPosition.Disconnect();
                headRotation.Disconnect();

                headLeftEyePupil.Disconnect();
                headLeftEyeBlink.Disconnect();

                headRightEyePupil.Disconnect();
                headRightEyeBlink.Disconnect();

                // Left hand
                leftHandPosition.Disconnect();
                leftHandRotation.Disconnect();

                leftHandThumbStickTouch.Disconnect();
                leftHandThumbStickPush.Disconnect();
                leftHandThumbStickTilt.Disconnect();

                leftHandFingerTriggerTouch.Disconnect();
                leftHandFingerTriggerPull.Disconnect();

                leftHandFingerTriggerTouch.Disconnect();
                leftHandFingerTriggerPull.Disconnect();

                // Right hand
                rightHandPosition.Disconnect();
                rightHandRotation.Disconnect();

                rightHandThumbStickTouch.Disconnect();
                rightHandThumbStickPush.Disconnect();
                rightHandThumbStickTilt.Disconnect();

                rightHandFingerTriggerTouch.Disconnect();
                rightHandFingerTriggerPull.Disconnect();

                rightHandFingerTriggerTouch.Disconnect();
                rightHandFingerTriggerPull.Disconnect();
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
            var position = configuration.PoseTracker.Position.Produce(HardwareHandler.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Produce(HardwareHandler.PoseTracker.Rotation);

            // Head
            var headDirection = configuration.Head.Direction.Produce(HardwareHandler.Head.Direction);

            var headPosition = configuration.Head.PoseTracker.Position.Produce(HardwareHandler.Head.PoseTracker.Position);
            var headRotation = configuration.Head.PoseTracker.Rotation.Produce(HardwareHandler.Head.PoseTracker.Rotation);

            var headLeftEyePupil = configuration.Head.LeftEye.Pupil.Produce(HardwareHandler.Head.LeftEye.Pupil);
            var headLeftEyeBlink = configuration.Head.LeftEye.Blink.Produce(HardwareHandler.Head.LeftEye.Blink);

            var headRightEyePupil = configuration.Head.RightEye.Pupil.Produce(HardwareHandler.Head.RightEye.Pupil);
            var headRightEyeBlink = configuration.Head.RightEye.Blink.Produce(HardwareHandler.Head.RightEye.Blink);

            // Left hand
            var leftHandPosition = configuration.LeftHand.PoseTracker.Position.Produce(HardwareHandler.LeftHand.PoseTracker.Position);
            var leftHandRotation = configuration.LeftHand.PoseTracker.Rotation.Produce(HardwareHandler.LeftHand.PoseTracker.Rotation);

            var leftHandThumbStickTouch = configuration.LeftHand.ThumbStick.Touch.Produce(HardwareHandler.LeftHand.ThumbStick.Touch);
            var leftHandThumbStickPush = configuration.LeftHand.ThumbStick.Push.Produce(HardwareHandler.LeftHand.ThumbStick.Push);
            var leftHandThumbStickTilt = configuration.LeftHand.ThumbStick.Tilt.Produce(HardwareHandler.LeftHand.ThumbStick.Tilt);

            var leftHandFingerTriggerTouch = configuration.LeftHand.FingerTrigger.Touch.Produce(HardwareHandler.LeftHand.FingerTrigger.Touch);
            var leftHandFingerTriggerPull = configuration.LeftHand.FingerTrigger.Pull.Produce(HardwareHandler.LeftHand.FingerTrigger.Pull);

            var leftHandHandTriggerTouch = configuration.LeftHand.HandTrigger.Touch.Produce(HardwareHandler.LeftHand.HandTrigger.Touch);
            var leftHandHandTriggerPull = configuration.LeftHand.HandTrigger.Pull.Produce(HardwareHandler.LeftHand.HandTrigger.Pull);

            // Right hand
            var rightHandPosition = configuration.RightHand.PoseTracker.Position.Produce(HardwareHandler.RightHand.PoseTracker.Position);
            var rightHandRotation = configuration.RightHand.PoseTracker.Rotation.Produce(HardwareHandler.RightHand.PoseTracker.Rotation);

            var rightHandThumbStickTouch = configuration.RightHand.ThumbStick.Touch.Produce(HardwareHandler.RightHand.ThumbStick.Touch);
            var rightHandThumbStickPush = configuration.RightHand.ThumbStick.Push.Produce(HardwareHandler.RightHand.ThumbStick.Push);
            var rightHandThumbStickTilt = configuration.RightHand.ThumbStick.Tilt.Produce(HardwareHandler.RightHand.ThumbStick.Tilt);

            var rightHandFingerTriggerTouch = configuration.RightHand.FingerTrigger.Touch.Produce(HardwareHandler.RightHand.FingerTrigger.Touch);
            var rightHandFingerTriggerPull = configuration.RightHand.FingerTrigger.Pull.Produce(HardwareHandler.RightHand.FingerTrigger.Pull);

            var rightHandHandTriggerTouch = configuration.RightHand.HandTrigger.Touch.Produce(HardwareHandler.RightHand.HandTrigger.Touch);
            var rightHandHandTriggerPull = configuration.RightHand.HandTrigger.Pull.Produce(HardwareHandler.RightHand.HandTrigger.Pull);

            return new Emission(() =>
            {
                position.Emit();
                rotation.Emit();

                // Head
                headDirection.Emit();

                headPosition.Emit();
                headRotation.Emit();

                headLeftEyePupil.Emit();
                headLeftEyeBlink.Emit();

                headRightEyePupil.Emit();
                headRightEyeBlink.Emit();

                // Left hand
                leftHandPosition.Emit();
                leftHandRotation.Emit();

                leftHandThumbStickTouch.Emit();
                leftHandThumbStickPush.Emit();
                leftHandThumbStickTilt.Emit();

                leftHandFingerTriggerTouch.Emit();
                leftHandFingerTriggerPull.Emit();

                leftHandFingerTriggerTouch.Emit();
                leftHandFingerTriggerPull.Emit();

                // Right hand
                rightHandPosition.Emit();
                rightHandRotation.Emit();

                rightHandThumbStickTouch.Emit();
                rightHandThumbStickPush.Emit();
                rightHandThumbStickTilt.Emit();

                rightHandFingerTriggerTouch.Emit();
                rightHandFingerTriggerPull.Emit();

                rightHandFingerTriggerTouch.Emit();
                rightHandFingerTriggerPull.Emit();
            });
        }

        #endregion
    }
}
