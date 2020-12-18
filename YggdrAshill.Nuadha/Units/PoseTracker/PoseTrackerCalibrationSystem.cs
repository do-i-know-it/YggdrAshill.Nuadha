using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerCalibrationSystem :
        ISoftware<IPoseTrackerSoftwareHandler>,
        IDisconnection
    {
        private readonly PositionCalibrationSystem position;

        private readonly RotationCalibrationSystem rotation;

        public PoseTrackerCalibrationSystem(IPoseTrackerCalibration calibration, IPoseTrackerHardwareHandler handler)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            position = new PositionCalibrationSystem(calibration.Position, handler.Position);

            rotation = new RotationCalibrationSystem(calibration.Rotation, handler.Rotation);
        }

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

        public void Disconnect()
        {
            position.Disconnect();

            rotation.Disconnect();
        }
    }
}
