using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Consumes <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class ConsumeToConvert<TInput, TOutput> :
        IConsumption<TInput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConversion<TInput, TOutput> conversion;

        private readonly IConsumption<TOutput> consumption;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public ConsumeToConvert(IConversion<TInput, TOutput> conversion, IConsumption<TOutput> consumption)
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            this.conversion = conversion;

            this.consumption = consumption;
        }

        /// <summary>
        /// Consumes <paramref name="signal"/> to convert.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
        /// </param>
        public void Consume(TInput signal)
        {
            var converted = conversion.Convert(signal);

            consumption.Consume(converted);
        }
    }
}
