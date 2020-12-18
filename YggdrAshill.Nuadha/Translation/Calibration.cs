using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Calibration<TSignal> :
        ICalibration<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal> onCalibrated;

        #region Constructor

        public Calibration(Func<TSignal> onCalibrated)
        {
            if (onCalibrated == null)
            {
                throw new ArgumentNullException(nameof(onCalibrated));
            }

            this.onCalibrated = onCalibrated;
        }

        public Calibration(TSignal offset)
        {
            onCalibrated = () =>
            {
                return offset;
            };
        }

        #endregion

        #region ICalibration

        public TSignal Calibrate()
        {
            return onCalibrated.Invoke();
        }

        #endregion
    }
}
