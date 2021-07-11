using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    public static class ConversionExtension
    {
        #region IConversion

        public static IConversion<TInput, TOutput> Then<TInput, TMedium, TOutput>(this IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            if (inputToMedium == null)
            {
                throw new ArgumentNullException(nameof(inputToMedium));
            }
            if (mediumToOutput == null)
            {
                throw new ArgumentNullException(nameof(mediumToOutput));
            }

            return new ConvertIntermediate<TInput, TMedium, TOutput>(inputToMedium, mediumToOutput);
        }
        private sealed class ConvertIntermediate<TInput, TMedium, TOutput> :
            IConversion<TInput, TOutput>
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            private readonly IConversion<TInput, TMedium> inputToMedium;

            private readonly IConversion<TMedium, TOutput> mediumToOutput;

            internal ConvertIntermediate(IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
            {
                this.inputToMedium = inputToMedium;

                this.mediumToOutput = mediumToOutput;
            }

            /// <inheritdoc/>
            public TOutput Convert(TInput signal)
            {
                var medium = inputToMedium.Convert(signal);

                return mediumToOutput.Convert(medium);
            }
        }

        #endregion

        #region ICorrection

        public static IConversion<TSignal, TSignal> AsConversion<TSignal>(this ICorrection<TSignal> correction)
            where TSignal : ISignal
        {
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return new Correct<TSignal>(correction);
        }
        private sealed class Correct<TSignal> :
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

        public static ICorrection<TSignal> Then<TSignal>(this ICorrection<TSignal> correction, ICorrection<TSignal> hoge)
            where TSignal : ISignal
        {
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }
            if (hoge == null)
            {
                throw new ArgumentNullException(nameof(hoge));
            }

            return new CorrectIntermediate<TSignal>(correction, hoge);
        }
        private sealed class CorrectIntermediate<TSignal> :
            ICorrection<TSignal>
            where TSignal : ISignal
        {
            private readonly ICorrection<TSignal> correction;

            private readonly ICorrection<TSignal> hoge;

            internal CorrectIntermediate(ICorrection<TSignal> correction, ICorrection<TSignal> hoge)
            {
                this.correction = correction;

                this.hoge = hoge;
            }

            /// <inheritdoc/>
            public TSignal Correct(TSignal signal)
            {
                var medium = correction.Correct(signal);

                return hoge.Correct(medium);
            }
        }

        #endregion
    }
}
