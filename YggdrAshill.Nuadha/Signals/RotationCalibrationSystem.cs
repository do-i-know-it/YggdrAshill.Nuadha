using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class RotationCalibrationSystem :
        IInputTerminal<Rotation>,
        IDisconnection
    {
        private readonly CalibrationSystem<Rotation> calibrationSystem;

        #region Constructor

        public RotationCalibrationSystem(ICalibration<Rotation> calibration, IInputTerminal<Rotation> terminal)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            calibrationSystem = new CalibrationSystem<Rotation>(Calibrate.Rotation, calibration, terminal);
        }

        public RotationCalibrationSystem(Func<Rotation> calibration, IInputTerminal<Rotation> terminal)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            calibrationSystem = new CalibrationSystem<Rotation>(Calibrate.Rotation, new Calibration<Rotation>(calibration), terminal);
        }

        public RotationCalibrationSystem(Rotation offset, IInputTerminal<Rotation> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            var calibration = new Calibration<Rotation>(offset);

            calibrationSystem = new CalibrationSystem<Rotation>(Calibrate.Rotation, calibration, terminal);
        }

        #endregion

        #region IInputTerminal

        public void Receive(Rotation signal)
        {
            calibrationSystem.Receive(signal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            calibrationSystem.Disconnect();
        }

        #endregion
    }
}
