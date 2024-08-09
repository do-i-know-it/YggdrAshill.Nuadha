using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> via <typeparamref name="TMedium"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TMedium">
    /// Type of <see cref="ISignal"/> converted from <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class ConvertIntermediate<TInput, TMedium, TOutput> : IConversion<TInput, TOutput>
        where TInput : ISignal
        where TMedium : ISignal
        where TOutput : ISignal
    {
        private readonly IConversion<TInput, TMedium> inputToMedium;
        private readonly IConversion<TMedium, TOutput> mediumToOutput;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="inputToMedium">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TMedium"/>.
        /// </param>
        /// <param name="mediumToOutput">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
        /// </param>
        public ConvertIntermediate(IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
        {
            this.inputToMedium = inputToMedium;
            this.mediumToOutput = mediumToOutput;
        }

        /// <inheritdoc/>
        public TOutput Convert(TInput signal)
        {
            var converted = inputToMedium.Convert(signal);
            return mediumToOutput.Convert(converted);
        }
    }
}
