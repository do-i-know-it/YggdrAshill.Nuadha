using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations for <see cref="ICondition{TSignal}"/>.
    /// </summary>
    public static class NoticeOf
    {
        /// <summary>
        /// Executes <see cref="Func{T, TResult}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="Func{T, TResult}"/> to detect <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICondition{TSignal}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static ICondition<TSignal> Signal<TSignal>(Func<TSignal, bool> condition)
            where TSignal : ISignal
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Condition<TSignal>(condition);
        }
        private sealed class Condition<TSignal> :
            ICondition<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal, bool> condition;

            internal Condition(Func<TSignal, bool> condition)
            {
                this.condition = condition;
            }

            /// <inheritdoc/>
            public bool IsSatisfiedBy(TSignal signal)
            {
                return condition.Invoke(signal);
            }
        }

        /// <summary>
        /// Satisfied by all of <typeparamref name="TSignal"/> even if <typeparamref name="TSignal"/> is <see cref="null"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <returns>
        /// <see cref="ICondition{TSignal}"/> created.
        /// </returns>
        public static ICondition<TSignal> All<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => true);
        }

        /// <summary>
        /// Satisfied by none of <typeparamref name="TSignal"/> even if <typeparamref name="TSignal"/> is <see cref="null"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <returns>
        /// <see cref="ICondition{TSignal}"/> created.
        /// </returns>
        public static ICondition<TSignal> None<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => false);
        }
    }
}
