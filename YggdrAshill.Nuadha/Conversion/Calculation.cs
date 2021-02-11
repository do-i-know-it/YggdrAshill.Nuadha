using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="ICalculation{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to calculate.
    /// </typeparam>
    public sealed class Calculation<TSignal> :
        ICalculation<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, TSignal, TSignal> onCalculated;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onCalculated">
        /// <see cref="Func{TSignal, TSignal, TSignal}"/> to execute when this has calculated.
        /// </param>
        public Calculation(Func<TSignal, TSignal, TSignal> onCalculated)
        {
            if (onCalculated == null)
            {
                throw new ArgumentNullException(nameof(onCalculated));
            }

            this.onCalculated = onCalculated;
        }

        /// <inheritdoc/>
        public TSignal Calculate(TSignal left, TSignal right)
        {
            return onCalculated.Invoke(left, right);
        }
    }
}
