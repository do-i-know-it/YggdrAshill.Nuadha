using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Translation
{
    internal sealed class Calibrate<TSignal> :
        ICorrection<TSignal>
        where TSignal : ISignal
    {
        private readonly IReduction<TSignal> reduction;

        private readonly ICalibration<TSignal> calibration;

        public Calibrate(IReduction<TSignal> reduction, ICalibration<TSignal> calibration)
        {
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
