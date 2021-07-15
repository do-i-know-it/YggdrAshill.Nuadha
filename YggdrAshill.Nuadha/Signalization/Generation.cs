using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementation of <see cref="IGeneration{TSignal}"/>.
    /// </summary>
    public static class Generation
    {
        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to execute <see cref="Func{TResult}"/> when this has generated <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to generate.
        /// </typeparam>
        /// <param name="onGenerated">
        /// <see cref="Func{TResult}"/> to generate <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IGeneration{TSignal}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onGenerated"/> is null.
        /// </exception>
        public static IGeneration<TSignal> Of<TSignal>(Func<TSignal> onGenerated)
            where TSignal : ISignal
        {
            if (onGenerated == null)
            {
                throw new ArgumentNullException(nameof(onGenerated));
            }

            return new Created<TSignal>(onGenerated);
        }
        private sealed class Created<TSignal> :
            IGeneration<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal> onGenerated;

            internal Created(Func<TSignal> onGenerated)
            {
                this.onGenerated = onGenerated;
            }

            /// <inheritdoc/>
            public TSignal Generate()
            {
                return onGenerated.Invoke();
            }
        }

        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate same <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to generate.
        /// </typeparam>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to generate.
        /// </param>
        /// <returns>
        /// <see cref="IGeneration{TSignal}"/> created.
        /// </returns>
        public static IGeneration<TSignal> Of<TSignal>(TSignal signal)
            where TSignal : ISignal
        {
            return Of(() => signal);
        }
    }
}
