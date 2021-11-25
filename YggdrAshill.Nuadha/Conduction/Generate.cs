using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IGeneration{TSignal}"/>.
    /// </summary>
    public static class Generate
    {
        /// <summary>
        /// Converts <see cref="Func{TResult}"/> into <see cref="IGeneration{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to generate.
        /// </typeparam>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> for <typeparamref name="TSignal"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IGeneration{TSignal}"/> converted from <see cref="Func{TResult}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IGeneration<TSignal> Signal<TSignal>(Func<TSignal> generation)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return new Generation<TSignal>(generation);
        }
        private sealed class Generation<TSignal> :
            IGeneration<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal> onGenerated;

            internal Generation(Func<TSignal> onGenerated)
            {
                this.onGenerated = onGenerated;
            }

            public TSignal Generate()
            {
                return onGenerated.Invoke();
            }
        }

        /// <summary>
        /// Generates fixed <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to generate.
        /// </typeparam>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to generate.
        /// </param>
        /// <returns>
        /// <see cref="IGeneration{TSignal}"/> to generate fixed <typeparamref name="TSignal"/>.
        /// </returns>
        public static IGeneration<TSignal> Signal<TSignal>(TSignal signal)
            where TSignal : ISignal
        {
            return Signal(() => signal);
        }
    }
}
