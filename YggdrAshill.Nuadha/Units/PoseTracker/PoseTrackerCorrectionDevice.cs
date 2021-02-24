using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerCorrectionDevice :
        IDevice<IPoseTrackerSoftware>
    {
        private readonly IConnection<Position> position;

        private readonly IConnection<Rotation> rotation;

        public PoseTrackerCorrectionDevice(IPoseTrackerHardware hardware, IPoseTrackerCalculation calculation, IPoseTrackerCalibration calibration)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            position = hardware.Position.Correct(calculation.Position, calibration.Position);

            rotation = hardware.Rotation.Correct(calculation.Rotation, calibration.Rotation);
        }

        public IDisconnection Connect(IPoseTrackerSoftware system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var position = this.position.Connect(system.Position);

            var rotation = this.rotation.Connect(system.Rotation);

            return new Disconnection(() =>
            {
                position.Disconnect();

                rotation.Disconnect();
            });
        }
    }
}
