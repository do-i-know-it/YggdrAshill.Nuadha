using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines <see cref="IProduction{TSignal}"/> and <see cref="ICondition{TSignal}"/> for <see cref="ICondition{TSignal}"/>.
    /// </summary>
    public static class Detection
    {
        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="ICondition{TSignal}"/> to detect.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Notice"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> to consume <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TSignal> Consume<TSignal>(ICondition<TSignal> condition, IConsumption<Notice> consumption)
            where TSignal : ISignal
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new Consumption<TSignal>(condition, consumption);
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

            public void Consume(TSignal signal)
            {
                if (condition.IsSatisfiedBy(signal))
                {
                    consumption.Consume(Notice.Instance);
                }
            }
        }

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="condition">
        /// <see cref="ICondition{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Notice"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IProduction<Notice> Produce<TSignal>(IProduction<TSignal> production, ICondition<TSignal> condition)
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

            public ICancellation Produce(IConsumption<Notice> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return production.Produce(Consume(condition, consumption));
            }
        }
    }
}
