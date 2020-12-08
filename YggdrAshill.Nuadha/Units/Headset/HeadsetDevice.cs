using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetDevice :
        IHardware<IHeadsetHardwareHandler>,
        IDisconnection,
        IIgnition
    {
        private readonly IHeadsetConfiguration configuration;

        private readonly HeadsetModule module = new HeadsetModule();

        public HeadsetDevice(IHeadsetConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        private IHeadsetSoftwareHandler SoftwareHandler => module;

        public IDisconnection Connect(IHeadsetHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var direction = SoftwareHandler.Direction.Connect(handler.Direction);
            
            var position = SoftwareHandler.PoseTracker.Position.Connect(handler.PoseTracker.Position);
            var rotation = SoftwareHandler.PoseTracker.Rotation.Connect(handler.PoseTracker.Rotation);

            var leftEyePupil = SoftwareHandler.LeftEye.Pupil.Connect(handler.LeftEye.Pupil);
            var leftEyeBlink = SoftwareHandler.LeftEye.Blink.Connect(handler.LeftEye.Blink);

            var rightEyePupil = SoftwareHandler.RightEye.Pupil.Connect(handler.RightEye.Pupil);
            var rightEyeBlink = SoftwareHandler.RightEye.Blink.Connect(handler.RightEye.Blink);

            return new Disconnection(() =>
            {
                direction.Disconnect();

                position.Disconnect();
                rotation.Disconnect();

                leftEyePupil.Disconnect();
                leftEyeBlink.Disconnect();

                rightEyePupil.Disconnect();
                rightEyeBlink.Disconnect();
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

        private IHeadsetHardwareHandler HardwareHandler => module;

        public IEmission Ignite()
        {
            var direction = configuration.Direction.Connect(HardwareHandler.Direction);

            var position = configuration.PoseTracker.Position.Connect(HardwareHandler.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Connect(HardwareHandler.PoseTracker.Rotation);

            var leftEyePupil = configuration.LeftEye.Pupil.Connect(HardwareHandler.LeftEye.Pupil);
            var leftEyeBlink = configuration.LeftEye.Blink.Connect(HardwareHandler.LeftEye.Blink);

            var rightEyePupil = configuration.RightEye.Pupil.Connect(HardwareHandler.RightEye.Pupil);
            var rightEyeBlink = configuration.RightEye.Blink.Connect(HardwareHandler.RightEye.Blink);

            return new Emission(() =>
            {
                direction.Emit();

                position.Emit();
                rotation.Emit();

                leftEyePupil.Emit();
                leftEyeBlink.Emit();

                rightEyePupil.Emit();
                rightEyeBlink.Emit();
            });
        }

        #endregion
    }
}
