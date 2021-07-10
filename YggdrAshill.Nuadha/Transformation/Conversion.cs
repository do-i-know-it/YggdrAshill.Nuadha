using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IConversion{TInput, TOutput}"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class Conversion<TInput, TOutput> :
        IConversion<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly Func<TInput, TOutput> onConverted;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onConverted">
        /// <see cref="Func{TInput, TOutput}"/> to execute when this has converted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onConverted"/> is null.
        /// </exception>
        public Conversion(Func<TInput, TOutput> onConverted)
        {
            if (onConverted == null)
            {
                throw new ArgumentNullException(nameof(onConverted));
            }

            this.onConverted = onConverted;
        }

        /// <inheritdoc/>
        public TOutput Convert(TInput signal)
        {
            return onConverted.Invoke(signal);
        }
    }
}
