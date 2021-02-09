using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerCalibrationSystem :
        ISoftware<IPoseTrackerSoftwareHandler>,
        IHardware<IPoseTrackerHardwareHandler>,
        IDisconnection
    {
        private readonly PositionCalibrationSystem position;

        private readonly RotationCalibrationSystem rotation;

        public PoseTrackerCalibrationSystem(IPoseTrackerCalibration calibration)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            position = new PositionCalibrationSystem(calibration.Position);

            rotation = new RotationCalibrationSystem(calibration.Rotation);
        }

        #region ISoftware

        public IDisconnection Connect(IPoseTrackerSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var position = handler.Position.Connect(this.position);

            var rotation = handler.Rotation.Connect(this.rotation);

            return new Disconnection(() =>
            {
                position.Disconnect();

                rotation.Disconnect();
            });
        }

        #endregion

        #region IHardware

        public IDisconnection Connect(IPoseTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var position = this.position.Connect(handler.Position);

            var rotation = this.rotation.Connect(handler.Rotation);

            return new Disconnection(() =>
            {
                position.Disconnect();

                rotation.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            position.Disconnect();

            rotation.Disconnect();
        }

        #endregion
    }
}
