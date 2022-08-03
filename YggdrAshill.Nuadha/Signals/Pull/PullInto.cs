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
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Pull"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Signals.Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static ITranslation<Pull, Push> Push(INotification<Pull> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return SignalInto.Signal<Pull, Push>(signal => notification.Notify(signal).ToPush());
        }

        /// <summary>
        /// Converts <see cref="Pull"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Pull"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Signals.Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static ITranslation<Pull, Touch> Touch(INotification<Pull> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return SignalInto.Signal<Pull, Touch>(signal => notification.Notify(signal).ToTouch());
        }

        /// <summary>
        /// Converts <see cref="Pull"/> into <see cref="Transformation.Pulse"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to pulsate.
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

            return PulseFrom.Signal(PullIs.Over(threshold));
        }
    }
}
