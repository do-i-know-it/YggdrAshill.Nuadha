using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDevice :
        IInputHardware<IHandControllerSystem>
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

        private IHandControllerDevice Device => module;
        public IDisconnection Connect(IHandControllerSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var position = Device.PoseTracker.Position.Connect(system.PoseTracker.Position);
            var rotation = Device.PoseTracker.Rotation.Connect(system.PoseTracker.Rotation);

            var thumbStickTouch = Device.ThumbStick.Touch.Connect(system.ThumbStick.Touch);
            var thumbStickTilt = Device.ThumbStick.Tilt.Connect(system.ThumbStick.Tilt);

            var fingerTriggerTouch = Device.FingerTrigger.Touch.Connect(system.FingerTrigger.Touch);
            var fingerTriggerPull = Device.FingerTrigger.Pull.Connect(system.FingerTrigger.Pull);

            var handTriggerTouch = Device.HandTrigger.Touch.Connect(system.HandTrigger.Touch);
            var handTriggerPull = Device.HandTrigger.Pull.Connect(system.HandTrigger.Pull);

            return new Disconnection(() =>
            {
                position.Disconnect();
                rotation.Disconnect();

                thumbStickTouch.Disconnect();
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

        private IHandControllerSystem System => module;
        public IEmission Ignite()
        {
            var position = configuration.PoseTracker.Position.Produce(System.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Produce(System.PoseTracker.Rotation);

            var thumbStickTouch = configuration.ThumbStick.Touch.Produce(System.ThumbStick.Touch);
            var thumbStickTilt = configuration.ThumbStick.Tilt.Produce(System.ThumbStick.Tilt);

            var fingerTriggerTouch = configuration.FingerTrigger.Touch.Produce(System.FingerTrigger.Touch);
            var fingerTriggerPull = configuration.FingerTrigger.Pull.Produce(System.FingerTrigger.Pull);

            var handTriggerTouch = configuration.HandTrigger.Touch.Produce(System.HandTrigger.Touch);
            var handTriggerPull = configuration.HandTrigger.Pull.Produce(System.HandTrigger.Pull);

            return new Emission(() =>
            {
                position.Emit();
                rotation.Emit();

                thumbStickTouch.Emit();
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
