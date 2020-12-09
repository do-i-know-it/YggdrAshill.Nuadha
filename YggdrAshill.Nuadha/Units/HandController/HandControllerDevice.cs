using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDevice :
        IHardware<IHandControllerHardwareHandler>,
        IDisconnection,
        IIgnitor
    {
        private readonly IHandControllerConfiguration configuration;

        public HandControllerDevice(IHandControllerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        public IDisconnection Connect(IHandControllerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var position = configuration.PoseTracker.Position.Connect(handler.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Connect(handler.PoseTracker.Rotation);

            var thumbStickTouch = configuration.ThumbStick.Touch.Connect(handler.ThumbStick.Touch);
            var thumbStickPush = configuration.ThumbStick.Push.Connect(handler.ThumbStick.Push);
            var thumbStickTilt = configuration.ThumbStick.Tilt.Connect(handler.ThumbStick.Tilt);

            var fingerTriggerTouch = configuration.FingerTrigger.Touch.Connect(handler.FingerTrigger.Touch);
            var fingerTriggerPull = configuration.FingerTrigger.Pull.Connect(handler.FingerTrigger.Pull);

            var handTriggerTouch = configuration.HandTrigger.Touch.Connect(handler.HandTrigger.Touch);
            var handTriggerPull = configuration.HandTrigger.Pull.Connect(handler.HandTrigger.Pull);

            return new Disconnection(() =>
            {
                position.Disconnect();
                rotation.Disconnect();

                thumbStickTouch.Disconnect();
                thumbStickPush.Disconnect();
                thumbStickTilt.Disconnect();

                fingerTriggerTouch.Disconnect();
                fingerTriggerPull.Disconnect();

                fingerTriggerTouch.Disconnect();
                fingerTriggerPull.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            configuration.PoseTracker.Position.Disconnect();
            configuration.PoseTracker.Rotation.Disconnect();

            configuration.ThumbStick.Touch.Disconnect();
            configuration.ThumbStick.Push.Disconnect();
            configuration.ThumbStick.Tilt.Disconnect();

            configuration.FingerTrigger.Touch.Disconnect();
            configuration.FingerTrigger.Pull.Disconnect();

            configuration.HandTrigger.Touch.Disconnect();
            configuration.HandTrigger.Pull.Disconnect();
        }

        #endregion

        #region Ignitor

        public IEmission Ignite()
        {
            var position = configuration.PoseTracker.Position.Ignite();
            var rotation = configuration.PoseTracker.Rotation.Ignite();

            var thumbStickTouch = configuration.ThumbStick.Touch.Ignite();
            var thumbStickPush = configuration.ThumbStick.Push.Ignite();
            var thumbStickTilt = configuration.ThumbStick.Tilt.Ignite();

            var fingerTriggerTouch = configuration.FingerTrigger.Touch.Ignite();
            var fingerTriggerPull = configuration.FingerTrigger.Pull.Ignite();

            var handTriggerTouch = configuration.HandTrigger.Touch.Ignite();
            var handTriggerPull = configuration.HandTrigger.Pull.Ignite();

            return new Emission(() =>
            {
                position.Emit();
                rotation.Emit();

                thumbStickTouch.Emit();
                thumbStickPush.Emit();
                thumbStickTilt.Emit();

                fingerTriggerTouch.Emit();
                fingerTriggerPull.Emit();

                fingerTriggerTouch.Emit();
                fingerTriggerPull.Emit();
            });
        }

        #endregion
    }
}
