using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="ICorrection{TSignal}"/>.
    /// </summary>
    public static class CorrectionExtension
    {
        public static IConversion<TSignal, TSignal> ToConversion<TSignal>(this ICorrection<TSignal> correction)
            where TSignal : ISignal
        {
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return new Correction<TSignal>(correction);
        }
        private sealed class Correction<TSignal> :
            IConversion<TSignal, TSignal>
            where TSignal : ISignal
        {
            private readonly ICorrection<TSignal> correction;

            internal Correction(ICorrection<TSignal> correction)
            {
                this.correction = correction;
            }

            public TSignal Convert(TSignal signal)
            {
                return correction.Correct(signal);
            }
        }

        public static ICorrection<TSignal> Then<TSignal>(this ICorrection<TSignal> first, ICorrection<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new Intermediate<TSignal>(first, second);
        }
        private sealed class Intermediate<TSignal> :
            ICorrection<TSignal>
            where TSignal : ISignal
        {
            private readonly ICorrection<TSignal> first;

            private readonly ICorrection<TSignal> second;

            internal Intermediate(ICorrection<TSignal> first, ICorrection<TSignal> second)
            {
                this.first = first;

                this.second = second;
            }

            /// <inheritdoc/>
            public TSignal Correct(TSignal signal)
            {
                var corrected = first.Correct(signal);

                return second.Correct(corrected);
            }
        }
    }
}
