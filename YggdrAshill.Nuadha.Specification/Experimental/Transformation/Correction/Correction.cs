using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Transformation.Experimental;
using System;

namespace YggdrAshill.Nuadha.Experimental
{
    /// <summary>
    /// Implementation of <see cref="ICorrection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to correct.
    /// </typeparam>
    public sealed class Correction<TSignal> :
        ICorrection<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, TSignal> onCorrected;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onCorrected">
        /// <see cref="Func{TInput, TOutput}"/> to execute when this has corrected.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onCorrected"/> is null.
        /// </exception>
        public Correction(Func<TSignal, TSignal> onCorrected)
        {
            if (onCorrected == null)
            {
                throw new ArgumentNullException(nameof(onCorrected));
            }

            this.onCorrected = onCorrected;
        }

        /// <summary>
        /// Constructs an instance to do nothing when this has corrected.
        /// </summary>
        public Correction()
        {
            onCorrected = (signal) =>
            {
                return signal;
            };
        }

        /// <inheritdoc/>
        public TSignal Correct(TSignal signal)
        {
            return onCorrected.Invoke(signal);
        }
    }
}
