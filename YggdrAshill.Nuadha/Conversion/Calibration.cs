using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="ICalibration{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to calibrate.
    /// </typeparam>
    public sealed class Calibration<TSignal> :
        ICalibration<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal> onCalibrated;

        #region Constructor

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onCalibrated">
        /// <see cref="Func{TSignal}"/> to execute when this has calibrated.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onCalibrated"/> is null.
        /// </exception>
        public Calibration(Func<TSignal> onCalibrated)
        {
            if (onCalibrated == null)
            {
                throw new ArgumentNullException(nameof(onCalibrated));
            }

            this.onCalibrated = onCalibrated;
        }

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="offset"></param>
        public Calibration(TSignal offset)
        {
            onCalibrated = () =>
            {
                return offset;
            };
        }

        #endregion

        #region ICalibration

        /// <inheritdoc/>
        public TSignal Calibrate()
        {
            return onCalibrated.Invoke();
        }

        #endregion
    }
}
