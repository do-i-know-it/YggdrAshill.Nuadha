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
        IIgnition
    {
        private readonly IHandControllerConfiguration configuration;

        private readonly HandControllerModule module = new HandControllerModule();

        public HandControllerDevice(IHandControllerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        private IHandControllerSoftwareHandler SoftwareHandler => module;

        public IDisconnection Connect(IHandControllerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var position = SoftwareHandler.PoseTracker.Position.Connect(handler.PoseTracker.Position);
            var rotation = SoftwareHandler.PoseTracker.Rotation.Connect(handler.PoseTracker.Rotation);

            var thumbStickTouch = SoftwareHandler.ThumbStick.Touch.Connect(handler.ThumbStick.Touch);
            var thumbStickPush = SoftwareHandler.ThumbStick.Push.Connect(handler.ThumbStick.Push);
            var thumbStickTilt = SoftwareHandler.ThumbStick.Tilt.Connect(handler.ThumbStick.Tilt);

            var fingerTriggerTouch = SoftwareHandler.FingerTrigger.Touch.Connect(handler.FingerTrigger.Touch);
            var fingerTriggerPull = SoftwareHandler.FingerTrigger.Pull.Connect(handler.FingerTrigger.Pull);

            var handTriggerTouch = SoftwareHandler.HandTrigger.Touch.Connect(handler.HandTrigger.Touch);
            var handTriggerPull = SoftwareHandler.HandTrigger.Pull.Connect(handler.HandTrigger.Pull);

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
            module.Disconnect();
        }

        #endregion

        #region Ignition

        private IHandControllerHardwareHandler HardwareHandler => module;

        public IEmission Ignite()
        {
            var position = configuration.PoseTracker.Position.Connect(HardwareHandler.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Connect(HardwareHandler.PoseTracker.Rotation);

            var thumbStickTouch = configuration.ThumbStick.Touch.Connect(HardwareHandler.ThumbStick.Touch);
            var thumbStickPush = configuration.ThumbStick.Push.Connect(HardwareHandler.ThumbStick.Push);
            var thumbStickTilt = configuration.ThumbStick.Tilt.Connect(HardwareHandler.ThumbStick.Tilt);

            var fingerTriggerTouch = configuration.FingerTrigger.Touch.Connect(HardwareHandler.FingerTrigger.Touch);
            var fingerTriggerPull = configuration.FingerTrigger.Pull.Connect(HardwareHandler.FingerTrigger.Pull);

            var handTriggerTouch = configuration.HandTrigger.Touch.Connect(HardwareHandler.HandTrigger.Touch);
            var handTriggerPull = configuration.HandTrigger.Pull.Connect(HardwareHandler.HandTrigger.Pull);

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
