using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    public static class PulseFrom
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
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IConversion<TSignal, Pulse> Signal<TSignal>(ICondition<TSignal> condition)
            where TSignal : ISignal
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Conversion<TSignal>(condition);
        }
        private sealed class Conversion<TSignal> :
            IConversion<TSignal, Pulse>
            where TSignal : ISignal
        {
            private readonly ICondition<TSignal> condition;

            private Pulse previous = Pulse.IsDisabled;

            internal Conversion(ICondition<TSignal> condition)
            {
                this.condition = condition;
            }

            /// <inheritdoc/>
            public Pulse Convert(TSignal signal)
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
