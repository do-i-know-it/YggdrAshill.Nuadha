using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    public static class ConversionExtension
    {
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

            return new Intermediate<TInput, TMedium, TOutput>(inputToMedium, mediumToOutput);
        }
        private sealed class Intermediate<TInput, TMedium, TOutput> :
            IConversion<TInput, TOutput>
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            private readonly IConversion<TInput, TMedium> inputToMedium;

            private readonly IConversion<TMedium, TOutput> mediumToOutput;

            internal Intermediate(IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
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
    }
}
