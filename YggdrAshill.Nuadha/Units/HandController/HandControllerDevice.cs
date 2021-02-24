using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDevice :
        IInputDevice<IHandControllerSoftware>
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

        #region IDevice

        private IHandControllerHardware Hardware => module;
        public IDisconnection Connect(IHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var position = Hardware.PoseTracker.Position.Connect(software.PoseTracker.Position);
            var rotation = Hardware.PoseTracker.Rotation.Connect(software.PoseTracker.Rotation);

            var thumbStickTouch = Hardware.ThumbStick.Touch.Connect(software.ThumbStick.Touch);
            var thumbStickTilt = Hardware.ThumbStick.Tilt.Connect(software.ThumbStick.Tilt);

            var fingerTriggerTouch = Hardware.FingerTrigger.Touch.Connect(software.FingerTrigger.Touch);
            var fingerTriggerPull = Hardware.FingerTrigger.Pull.Connect(software.FingerTrigger.Pull);

            var handTriggerTouch = Hardware.HandTrigger.Touch.Connect(software.HandTrigger.Touch);
            var handTriggerPull = Hardware.HandTrigger.Pull.Connect(software.HandTrigger.Pull);

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

        private IHandControllerSoftware Software => module;
        public IEmission Ignite()
        {
            var position = configuration.PoseTracker.Position.Produce(Software.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Produce(Software.PoseTracker.Rotation);

            var thumbStickTouch = configuration.ThumbStick.Touch.Produce(Software.ThumbStick.Touch);
            var thumbStickTilt = configuration.ThumbStick.Tilt.Produce(Software.ThumbStick.Tilt);

            var fingerTriggerTouch = configuration.FingerTrigger.Touch.Produce(Software.FingerTrigger.Touch);
            var fingerTriggerPull = configuration.FingerTrigger.Pull.Produce(Software.FingerTrigger.Pull);

            var handTriggerTouch = configuration.HandTrigger.Touch.Produce(Software.HandTrigger.Touch);
            var handTriggerPull = configuration.HandTrigger.Pull.Produce(Software.HandTrigger.Pull);

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
