using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementation of <see cref="IGeneration{TSignal}"/>.
    /// </summary>
    public static class Generation
    {
        /// <summary>
        /// Executes <see cref="Func{TResult}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to generate.
        /// </typeparam>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to generate <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IGeneration{TSignal}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IGeneration<TSignal> Of<TSignal>(Func<TSignal> generation)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return new Created<TSignal>(generation);
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
        /// Generates same <typeparamref name="TSignal"/>.
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
