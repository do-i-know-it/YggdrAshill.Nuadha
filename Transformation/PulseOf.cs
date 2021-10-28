using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementation of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class PulseOf
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pulse"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to be converted into <see cref="Pulse"/>.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="ICondition{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static ITranslation<TSignal, Pulse> Signal<TSignal>(ICondition<TSignal> condition)
            where TSignal : ISignal
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Translation<TSignal>(condition);
        }
        private sealed class Translation<TSignal> :
            ITranslation<TSignal, Pulse>
            where TSignal : ISignal
        {
            private readonly ICondition<TSignal> condition;

            private Pulse previous = Pulse.IsDisabled;

            internal Translation(ICondition<TSignal> condition)
            {
                this.condition = condition;
            }

            public Pulse Translate(TSignal signal)
            {
                if (previous == Pulse.IsDisabled || previous == Pulse.HasDisabled)
                {
                    previous = condition.IsSatisfiedBy(signal) ? Pulse.HasEnabled : Pulse.IsDisabled;
                }
                else if (previous == Pulse.IsEnabled || previous == Pulse.HasEnabled)
                {
                    previous = condition.IsSatisfiedBy(signal) ? Pulse.IsEnabled : Pulse.HasDisabled;
                }

                return previous;
            }
        }
    }
}
