using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Pull"/>.
    /// </summary>
    public static class PullInto
    {
        /// <summary>
        /// Converts <see cref="Pull"/> into <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Signals.Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static ITranslation<Pull, Push> Push(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            var condition = new Condition(threshold);
            return SignalInto.Signal<Pull, Push>(signal => condition.Notify(signal).ToPush());
        }
        private sealed class Condition :
            INotification<Pull>
        {
            private readonly HysteresisThreshold threshold;

            private bool previous = false;

            internal Condition(HysteresisThreshold threshold)
            {
                this.threshold = threshold;
            }

            /// <inheritdoc/>
            public bool Notify(Pull signal)
            {
                if (previous)
                {
                    return previous = threshold.Lower <= (float)signal;
                }
                else
                {
                    return previous = threshold.Upper <= (float)signal;
                }
            }
        }

        /// <summary>
        /// Converts <see cref="Pull"/> into <see cref="Transformation.Pulse"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Transformation.Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static ITranslation<Pull, Pulse> Pulse(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return Push(threshold).Then(PushInto.Pulse);
        }
    }
}
