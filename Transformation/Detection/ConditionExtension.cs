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
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>
        /// <see cref="ICondition{TSignal}"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static ICondition<TSignal> And<TSignal>(this ICondition<TSignal> first, ICondition<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new Multiply<TSignal>(first, second);
        }
        private sealed class Multiply<TSignal> :
            ICondition<TSignal>
            where TSignal : ISignal
        {
            private readonly ICondition<TSignal> first;

            private readonly ICondition<TSignal> second;

            internal Multiply(ICondition<TSignal> first, ICondition<TSignal> second)
            {
                this.first = first;

                this.second = second;
            }

            public bool IsSatisfiedBy(TSignal signal)
            {
                return first.IsSatisfiedBy(signal) && second.IsSatisfiedBy(signal);
            }
        }

        /// <summary>
        /// Adds two instances of <see cref="ICondition{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>
        /// <see cref="ICondition{TSignal}"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static ICondition<TSignal> Or<TSignal>(this ICondition<TSignal> first, ICondition<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new Add<TSignal>(first, second);
        }
        private sealed class Add<TSignal> :
            ICondition<TSignal>
            where TSignal : ISignal
        {
            private readonly ICondition<TSignal> first;

            private readonly ICondition<TSignal> second;

            internal Add(ICondition<TSignal> first, ICondition<TSignal> second)
            {
                this.first = first;

                this.second = second;
            }

            public bool IsSatisfiedBy(TSignal signal)
            {
                return first.IsSatisfiedBy(signal) || second.IsSatisfiedBy(signal);
            }
        }
    }
}
