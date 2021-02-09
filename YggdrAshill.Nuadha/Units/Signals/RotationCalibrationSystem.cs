using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class RotationCalibrationSystem : CalibrationSystem<Rotation>
    {
        protected override IPropagation<Rotation> Propagation { get; } = new Propagation<Rotation>();

        protected override IReduction<Rotation> Reduction { get; } = Calibrate.Rotation;

        protected override ICalibration<Rotation> Calibration { get; }

        #region Constructor

        public RotationCalibrationSystem(ICalibration<Rotation> calibration)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            Calibration = calibration;
        }

        public RotationCalibrationSystem(Func<Rotation> calibration)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            Calibration = new Calibration<Rotation>(calibration);
        }

        #endregion
    }
}
