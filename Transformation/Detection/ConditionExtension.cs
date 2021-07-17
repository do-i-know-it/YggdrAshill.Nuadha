using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="ICondition{TSignal}"/>.
    /// </summary>
    public static class ConditionExtension
    {
        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to detect.
        /// </param>
        /// <param name="condition">
        /// <see cref="ICondition{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Notice"/> detected.
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

        /// <summary>
        /// Inverts <see cref="ICondition{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="ICondition{TSignal}"/> to invert.
        /// </param>
        /// <returns>
        /// <see cref="ICondition{TSignal}"/> inverted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static ICondition<TSignal> Not<TSignal>(this ICondition<TSignal> condition)
            where TSignal : ISignal
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Invert<TSignal>(condition);
        }
        private sealed class Invert<TSignal> :
            ICondition<TSignal>
            where TSignal : ISignal
        {
            private readonly ICondition<TSignal> condition;

            internal Invert(ICondition<TSignal> condition)
            {
                this.condition = condition;
            }

            public bool IsSatisfiedBy(TSignal signal)
            {
                return !condition.IsSatisfiedBy(signal);
            }
        }

        /// <summary>
        /// Multiplies two instances of <see cref="ICondition{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// <see cref="ICondition{TSignal}"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        public static ICondition<TSignal> And<TSignal>(this ICondition<TSignal> left, ICondition<TSignal> right)
            where TSignal : ISignal
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Multiply<TSignal>(left, right);
        }
        private sealed class Multiply<TSignal> :
            ICondition<TSignal>
            where TSignal : ISignal
        {
            private readonly ICondition<TSignal> left;

            private readonly ICondition<TSignal> right;

            internal Multiply(ICondition<TSignal> left, ICondition<TSignal> right)
            {
                this.left = left;

                this.right = right;
            }

            public bool IsSatisfiedBy(TSignal signal)
            {
                return left.IsSatisfiedBy(signal) && right.IsSatisfiedBy(signal);
            }
        }

        /// <summary>
        /// Adds two instances of <see cref="ICondition{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// <see cref="ICondition{TSignal}"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        public static ICondition<TSignal> Or<TSignal>(this ICondition<TSignal> left, ICondition<TSignal> right)
            where TSignal : ISignal
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Add<TSignal>(left, right);
        }
        private sealed class Add<TSignal> :
            ICondition<TSignal>
            where TSignal : ISignal
        {
            private readonly ICondition<TSignal> left;

            private readonly ICondition<TSignal> right;

            internal Add(ICondition<TSignal> left, ICondition<TSignal> right)
            {
                this.left = left;

                this.right = right;
            }

            public bool IsSatisfiedBy(TSignal signal)
            {
                return left.IsSatisfiedBy(signal) || right.IsSatisfiedBy(signal);
            }
        }
    }
}
