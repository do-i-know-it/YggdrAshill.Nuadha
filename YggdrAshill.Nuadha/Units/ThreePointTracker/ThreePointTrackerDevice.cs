using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerDevice :
        IInputDevice<IThreePointTrackerHardwareHandler>
    {
        private readonly IThreePointTrackerConfiguration configuration;

        public ThreePointTrackerDevice(IThreePointTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        public IDisconnection Connect(IThreePointTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            // Head
            var headDirection = configuration.Head.Direction.Connect(handler.Head.Direction);

            var headPosition = configuration.Head.PoseTracker.Position.Connect(handler.Head.PoseTracker.Position);
            var headRotation = configuration.Head.PoseTracker.Rotation.Connect(handler.Head.PoseTracker.Rotation);

            var headLeftEyePupil = configuration.Head.LeftEye.Pupil.Connect(handler.Head.LeftEye.Pupil);
            var headLeftEyeBlink = configuration.Head.LeftEye.Blink.Connect(handler.Head.LeftEye.Blink);

            var headRightEyePupil = configuration.Head.RightEye.Pupil.Connect(handler.Head.RightEye.Pupil);
            var headRightEyeBlink = configuration.Head.RightEye.Blink.Connect(handler.Head.RightEye.Blink);

            // Left hand
            var leftHandPosition = configuration.LeftHand.PoseTracker.Position.Connect(handler.LeftHand.PoseTracker.Position);
            var leftHandRotation = configuration.LeftHand.PoseTracker.Rotation.Connect(handler.LeftHand.PoseTracker.Rotation);

            var leftHandThumbStickTouch = configuration.LeftHand.ThumbStick.Touch.Connect(handler.LeftHand.ThumbStick.Touch);
            var leftHandThumbStickPush = configuration.LeftHand.ThumbStick.Push.Connect(handler.LeftHand.ThumbStick.Push);
            var leftHandThumbStickTilt = configuration.LeftHand.ThumbStick.Tilt.Connect(handler.LeftHand.ThumbStick.Tilt);

            var leftHandFingerTriggerTouch = configuration.LeftHand.FingerTrigger.Touch.Connect(handler.LeftHand.FingerTrigger.Touch);
            var leftHandFingerTriggerPull = configuration.LeftHand.FingerTrigger.Pull.Connect(handler.LeftHand.FingerTrigger.Pull);

            var leftHandHandTriggerTouch = configuration.LeftHand.HandTrigger.Touch.Connect(handler.LeftHand.HandTrigger.Touch);
            var leftHandHandTriggerPull = configuration.LeftHand.HandTrigger.Pull.Connect(handler.LeftHand.HandTrigger.Pull);

            // Right hand
            var rightHandPosition = configuration.RightHand.PoseTracker.Position.Connect(handler.RightHand.PoseTracker.Position);
            var rightHandRotation = configuration.RightHand.PoseTracker.Rotation.Connect(handler.RightHand.PoseTracker.Rotation);

            var rightHandThumbStickTouch = configuration.RightHand.ThumbStick.Touch.Connect(handler.RightHand.ThumbStick.Touch);
            var rightHandThumbStickPush = configuration.RightHand.ThumbStick.Push.Connect(handler.RightHand.ThumbStick.Push);
            var rightHandThumbStickTilt = configuration.RightHand.ThumbStick.Tilt.Connect(handler.RightHand.ThumbStick.Tilt);

            var rightHandFingerTriggerTouch = configuration.RightHand.FingerTrigger.Touch.Connect(handler.RightHand.FingerTrigger.Touch);
            var rightHandFingerTriggerPull = configuration.RightHand.FingerTrigger.Pull.Connect(handler.RightHand.FingerTrigger.Pull);

            var rightHandHandTriggerTouch = configuration.RightHand.HandTrigger.Touch.Connect(handler.RightHand.HandTrigger.Touch);
            var rightHandHandTriggerPull = configuration.RightHand.HandTrigger.Pull.Connect(handler.RightHand.HandTrigger.Pull);

            return new Disconnection(() =>
            {
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
            // Head
            configuration.Head.Direction.Disconnect();
            
            configuration.Head.PoseTracker.Position.Disconnect();
            configuration.Head.PoseTracker.Rotation.Disconnect();
            
            configuration.Head.LeftEye.Pupil.Disconnect();
            configuration.Head.LeftEye.Blink.Disconnect();
            
            configuration.Head.RightEye.Pupil.Disconnect();
            configuration.Head.RightEye.Blink.Disconnect();

            // Left hand
            configuration.LeftHand.PoseTracker.Position.Disconnect();
            configuration.LeftHand.PoseTracker.Rotation.Disconnect();
            
            configuration.LeftHand.ThumbStick.Touch.Disconnect();
            configuration.LeftHand.ThumbStick.Push.Disconnect();
            configuration.LeftHand.ThumbStick.Tilt.Disconnect();
            
            configuration.LeftHand.FingerTrigger.Touch.Disconnect();
            configuration.LeftHand.FingerTrigger.Pull.Disconnect();
            
            configuration.LeftHand.HandTrigger.Touch.Disconnect();
            configuration.LeftHand.HandTrigger.Pull.Disconnect();

            // Right hand
            configuration.RightHand.PoseTracker.Position.Disconnect();
            configuration.RightHand.PoseTracker.Rotation.Disconnect();
            
            configuration.RightHand.ThumbStick.Touch.Disconnect();
            configuration.RightHand.ThumbStick.Push.Disconnect();
            configuration.RightHand.ThumbStick.Tilt.Disconnect();

            configuration.RightHand.FingerTrigger.Touch.Disconnect();
            configuration.RightHand.FingerTrigger.Pull.Disconnect();

            configuration.RightHand.HandTrigger.Touch.Disconnect();
            configuration.RightHand.HandTrigger.Pull.Disconnect();
        }

        #endregion

        #region Ignitor

        public IEmission Ignite()
        {
            // Head
            var headDirection = configuration.Head.Direction.Ignite();

            var headPosition = configuration.Head.PoseTracker.Position.Ignite();
            var headRotation = configuration.Head.PoseTracker.Rotation.Ignite();

            var headLeftEyePupil = configuration.Head.LeftEye.Pupil.Ignite();
            var headLeftEyeBlink = configuration.Head.LeftEye.Blink.Ignite();

            var headRightEyePupil = configuration.Head.RightEye.Pupil.Ignite();
            var headRightEyeBlink = configuration.Head.RightEye.Blink.Ignite();

            // Left hand
            var leftHandPosition = configuration.LeftHand.PoseTracker.Position.Ignite();
            var leftHandRotation = configuration.LeftHand.PoseTracker.Rotation.Ignite();

            var leftHandThumbStickTouch = configuration.LeftHand.ThumbStick.Touch.Ignite();
            var leftHandThumbStickPush = configuration.LeftHand.ThumbStick.Push.Ignite();
            var leftHandThumbStickTilt = configuration.LeftHand.ThumbStick.Tilt.Ignite();

            var leftHandFingerTriggerTouch = configuration.LeftHand.FingerTrigger.Touch.Ignite();
            var leftHandFingerTriggerPull = configuration.LeftHand.FingerTrigger.Pull.Ignite();

            var leftHandHandTriggerTouch = configuration.LeftHand.HandTrigger.Touch.Ignite();
            var leftHandHandTriggerPull = configuration.LeftHand.HandTrigger.Pull.Ignite();

            // Right hand
            var rightHandPosition = configuration.RightHand.PoseTracker.Position.Ignite();
            var rightHandRotation = configuration.RightHand.PoseTracker.Rotation.Ignite();

            var rightHandThumbStickTouch = configuration.RightHand.ThumbStick.Touch.Ignite();
            var rightHandThumbStickPush = configuration.RightHand.ThumbStick.Push.Ignite();
            var rightHandThumbStickTilt = configuration.RightHand.ThumbStick.Tilt.Ignite();

            var rightHandFingerTriggerTouch = configuration.RightHand.FingerTrigger.Touch.Ignite();
            var rightHandFingerTriggerPull = configuration.RightHand.FingerTrigger.Pull.Ignite();

            var rightHandHandTriggerTouch = configuration.RightHand.HandTrigger.Touch.Ignite();
            var rightHandHandTriggerPull = configuration.RightHand.HandTrigger.Pull.Ignite();

            return new Emission(() =>
            {
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
