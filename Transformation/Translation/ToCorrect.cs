using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to correct.
    /// </typeparam>
    public static class ToCorrect<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Corrects <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="calibration">
        /// <see cref="ICalibration{TSignal}"/> for <typeparamref name="TSignal"/> to correct.
        /// </param>
        /// <param name="offset">
        /// <see cref="IOffset{TSignal}"/> for <typeparamref name="TSignal"/> to correct.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to correct <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="calibration"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="offset"/> is null.
        /// </exception>
        public static ITranslation<TSignal, TSignal> With(ICalibration<TSignal> calibration, IOffset<TSignal> offset)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (offset == null)
            {
                throw new ArgumentNullException(nameof(offset));
            }

            return new TranslateToCalibrate(offset, calibration);
        }
        private sealed class TranslateToCalibrate :
            ITranslation<TSignal, TSignal>
        {
            private readonly IOffset<TSignal> offset;

            private readonly ICalibration<TSignal> calibration;

            internal TranslateToCalibrate(IOffset<TSignal> offset, ICalibration<TSignal> calibration)
            {
                this.offset = offset;

                this.calibration = calibration;
            }

            public TSignal Translate(TSignal signal)
            {
                return calibration.Calibrate(signal, offset.Signal);
            }
        }
    }
}
