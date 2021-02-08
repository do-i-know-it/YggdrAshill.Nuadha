using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Experimental
{
    public sealed class PositionCalibrationSystem : CalibrationSystem<Position>
    {
        protected override IPropagation<Position> Propagation { get; } = new Propagation<Position>();

        protected override IReduction<Position> Reduction { get; } = Calibrate.Position;

        protected override ICalibration<Position> Calibration { get; }

        #region Constructor

        public PositionCalibrationSystem(ICalibration<Position> calibration)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            Calibration = calibration;
        }

        public PositionCalibrationSystem(Func<Position> calibration)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            Calibration = new Calibration<Position>(calibration);
        }

        #endregion
    }
}
