using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> for input.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> for output.
    /// </typeparam>
    public sealed class Translation<TInput, TOutput> :
        ITranslation<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly Func<TInput, TOutput> onTranslated;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onTranslated">
        /// <see cref="Func{TInput, TOutput}"/> to execute when this has translated.
        /// </param>
        public Translation(Func<TInput, TOutput> onTranslated)
        {
            if (onTranslated == null)
            {
                throw new ArgumentNullException(nameof(onTranslated));
            }

            this.onTranslated = onTranslated;
        }

        /// <inheritdoc/>
        public TOutput Translate(TInput signal)
        {
            return onTranslated.Invoke(signal);
        }
    }
}
