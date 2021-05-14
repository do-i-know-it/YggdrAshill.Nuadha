﻿using YggdrAshill.Nuadha.Signalization.Experimental;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    internal sealed class Correct<TSignal> :
        IConversion<TSignal, TSignal>
        where TSignal : ISignal
    {
        private readonly ICorrection<TSignal> correction;

        internal Correct(ICorrection<TSignal> correction)
        {
            this.correction = correction;
        }

        public TSignal Convert(TSignal signal)
        {
            return correction.Correct(signal);
        }
    }
}