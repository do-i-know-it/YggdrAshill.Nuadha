using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class PulseFrom
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pulse"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> converted into <see cref="Pulse"/>.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="INotification{TSignal}"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static ITranslation<TSignal, Pulse> Signal<TSignal>(INotification<TSignal> condition)
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
            private readonly INotification<TSignal> condition;

            private Pulse previous = Pulse.IsDisabled;

            internal Translation(INotification<TSignal> condition)
            {
                this.condition = condition;
            }

            public Pulse Translate(TSignal signal)
            {
                if (previous == Pulse.IsDisabled || previous == Pulse.HasDisabled)
                {
                    previous = condition.Notify(signal) ? Pulse.HasEnabled : Pulse.IsDisabled;
                }
                else if (previous == Pulse.IsEnabled || previous == Pulse.HasEnabled)
                {
                    previous = condition.Notify(signal) ? Pulse.IsEnabled : Pulse.HasDisabled;
                }

                return previous;
            }
        }

        public static ITranslation<TSignal, Pulse> Signal<TSignal>(Func<TSignal, bool> condition)
            where TSignal : ISignal
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return Signal(NoticeOf.Signal(condition));
        }
    }
}
