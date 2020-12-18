using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Translation
{
    internal sealed class Corrector<TSignal> :
        IConversion<TSignal, TSignal>
        where TSignal : ISignal
    {
        private readonly ICorrection<TSignal> correction;

        internal Corrector(ICorrection<TSignal> correction)
        {
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            this.correction = correction;
        }

        public TSignal Convert(TSignal signal)
        {
            return correction.Correct(signal);
        }
    }
}
