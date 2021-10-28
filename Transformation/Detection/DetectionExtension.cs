using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions to detect <see cref="Notice"/> of <see cref="ISignal"/>.
    /// </summary>
    public static class DetectionExtension
    {
        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to send <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="condition">
        /// <see cref="ICondition{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to send <see cref="Notice"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, ICondition<TSignal> condition)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Production<TSignal>(production, condition);
        }
        private sealed class Production<TSignal> :
            IProduction<Notice>
            where TSignal : ISignal
        {
            private readonly IProduction<TSignal> production;

            private readonly ICondition<TSignal> condition;

            internal Production(IProduction<TSignal> production, ICondition<TSignal> condition)
            {
                this.production = production;

                this.condition = condition;
            }

            /// <inheritdoc/>
            public ICancellation Produce(IConsumption<Notice> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return production.Produce(new Consumption<TSignal>(condition, consumption));
            }
        }
        private sealed class Consumption<TSignal> :
            IConsumption<TSignal>
            where TSignal : ISignal
        {
            private readonly ICondition<TSignal> condition;

            private readonly IConsumption<Notice> consumption;

            internal Consumption(ICondition<TSignal> condition, IConsumption<Notice> consumption)
            {
                this.condition = condition;

                this.consumption = consumption;
            }

            /// <inheritdoc/>
            public void Consume(TSignal signal)
            {
                if (condition.IsSatisfiedBy(signal))
                {
                    consumption.Consume(Notice.Instance);
                }
            }
        }
    }
}
