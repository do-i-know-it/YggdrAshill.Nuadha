using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Calibration<TSignal> :
        ICorrection<TSignal>
        where TSignal : ISignal
    {
        private readonly IReduction<TSignal> reduction;

        private readonly TSignal offset;

        public Calibration(IReduction<TSignal> reduction, TSignal offset)
        {
            if (reduction == null)
            {
                throw new ArgumentNullException(nameof(reduction));
            }

            this.reduction = reduction;

            this.offset = offset;
        }

        public TSignal Correct(TSignal signal)
        {
            return reduction.Reduce(offset, signal);
        }
    }
}
