using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
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
        private readonly Func<TSignal> onGenerated;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onGenerated">
        /// <see cref="Func{TSignal}"/> to execute when this has generated.
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
