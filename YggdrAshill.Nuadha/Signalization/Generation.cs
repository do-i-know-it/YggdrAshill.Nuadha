using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IGeneration{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal"></typeparam>
    public sealed class Generation<TSignal> :
        IGeneration<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// <see cref="Generation{TSignal}"/> to generate same <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal"></param>
        /// <returns></returns>
        public static Generation<TSignal> Constant(TSignal signal)
        {
            return new Generation<TSignal>(() => signal);
        }

        private readonly Func<TSignal> onGenerated;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onGenerated">
        /// <see cref="Func{TResult}"/> to execute when this has generated <typeparamref name="TSignal"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onGenerated"/> is null.
        /// </exception>
        public Generation(Func<TSignal> onGenerated)
        {
            if (onGenerated == null)
            {
                throw new ArgumentNullException(nameof(onGenerated));
            }

            this.onGenerated = onGenerated;
        }

        /// <inheritdoc/>
        public TSignal Generate()
        {
            return onGenerated.Invoke();
        }
    }
}
