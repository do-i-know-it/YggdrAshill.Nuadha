using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Translation
{
    internal sealed class Calibrator<TSignal> :
        ICorrection<TSignal>
        where TSignal : ISignal
    {
        private readonly IReduction<TSignal> reduction;

        private readonly ICalibration<TSignal> calibration;

        public Calibrator(IReduction<TSignal> reduction, ICalibration<TSignal> calibration)
        {
            if (reduction == null)
            {
                throw new ArgumentNullException(nameof(reduction));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            
            this.reduction = reduction;
            
            this.calibration = calibration;
        }

        public TSignal Correct(TSignal signal)
        {
            var offset = calibration.Calibrate();

            return reduction.Reduce(signal, offset);
        }
    }
}
