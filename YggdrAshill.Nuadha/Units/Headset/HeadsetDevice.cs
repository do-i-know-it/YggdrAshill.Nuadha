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
        IIgnitor
    {
        private readonly IHeadsetConfiguration configuration;

        public HeadsetDevice(IHeadsetConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        public IDisconnection Connect(IHeadsetHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var direction = configuration.Direction.Connect(handler.Direction);

            var position = configuration.PoseTracker.Position.Connect(handler.PoseTracker.Position);
            var rotation = configuration.PoseTracker.Rotation.Connect(handler.PoseTracker.Rotation);

            var leftEyePupil = configuration.LeftEye.Pupil.Connect(handler.LeftEye.Pupil);
            var leftEyeBlink = configuration.LeftEye.Blink.Connect(handler.LeftEye.Blink);

            var rightEyePupil = configuration.RightEye.Pupil.Connect(handler.RightEye.Pupil);
            var rightEyeBlink = configuration.RightEye.Blink.Connect(handler.RightEye.Blink);

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
            configuration.Direction.Disconnect();

            configuration.PoseTracker.Position.Disconnect();
            configuration.PoseTracker.Rotation.Disconnect();

            configuration.LeftEye.Pupil.Disconnect();
            configuration.LeftEye.Blink.Disconnect();

            configuration.RightEye.Pupil.Disconnect();
            configuration.RightEye.Blink.Disconnect();
        }

        #endregion

        #region Ignitor

        public IEmission Ignite()
        {
            var direction = configuration.Direction.Ignite();

            var position = configuration.PoseTracker.Position.Ignite();
            var rotation = configuration.PoseTracker.Rotation.Ignite();

            var leftEyePupil = configuration.LeftEye.Pupil.Ignite();
            var leftEyeBlink = configuration.LeftEye.Blink.Ignite();

            var rightEyePupil = configuration.RightEye.Pupil.Ignite();
            var rightEyeBlink = configuration.RightEye.Blink.Ignite();

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
