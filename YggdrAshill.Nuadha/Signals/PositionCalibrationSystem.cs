using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PositionCalibrationSystem :
        IInputTerminal<Position>,
        IDisconnection
    {
        private readonly CalibrationSystem<Position> calibrationSystem;

        #region Constructor

        public PositionCalibrationSystem(ICalibration<Position> calibration, IInputTerminal<Position> terminal)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            calibrationSystem = new CalibrationSystem<Position>(Calibrate.Position, calibration, terminal);
        }

        public PositionCalibrationSystem(Func<Position> calibration, IInputTerminal<Position> terminal)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            calibrationSystem = new CalibrationSystem<Position>(Calibrate.Position, new Calibration<Position>(calibration), terminal);
        }

        public PositionCalibrationSystem(Position offset, IInputTerminal<Position> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            var calibration = new Calibration<Position>(offset);

            calibrationSystem = new CalibrationSystem<Position>(Calibrate.Position, calibration, terminal);
        }

        #endregion

        #region IInputTerminal

        public void Receive(Position signal)
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
