using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IReduction{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to calculate.
    /// </typeparam>
    public sealed class Reduction<TSignal> :
        IReduction<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, TSignal, TSignal> onReduced;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onReduced">
        /// <see cref="Func{TSignal, TSignal, TSignal}"/> to execute when this has calculated.
        /// </param>
        public Reduction(Func<TSignal, TSignal, TSignal> onReduced)
        {
            if (onReduced == null)
            {
                throw new ArgumentNullException(nameof(onReduced));
            }

            this.onReduced = onReduced;
        }

        /// <inheritdoc/>
        public TSignal Reduce(TSignal left, TSignal right)
        {
            return onReduced.Invoke(left, right);
        }
    }
}
