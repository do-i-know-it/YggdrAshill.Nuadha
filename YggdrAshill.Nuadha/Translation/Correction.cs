using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Correction<TSignal> :
        ICorrection<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, TSignal> onCorrected;

        #region Constructor

        public Correction(Func<TSignal, TSignal> onCorrected)
        {
            if (onCorrected == null)
            {
                throw new ArgumentNullException(nameof(onCorrected));
            }

            this.onCorrected = onCorrected;
        }

        public Correction()
        {
            onCorrected = (signal) =>
            {
                return signal;
            };
        }

        #endregion

        #region ICorrection

        public TSignal Correct(TSignal signal)
        {
            return onCorrected.Invoke(signal);
        }

        #endregion
    }
}
