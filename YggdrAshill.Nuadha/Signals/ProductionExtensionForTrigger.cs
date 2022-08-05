using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Trigger"/>.
    /// </summary>
    public static class ProductionExtensionForTrigger
    {
        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Trigger."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Touch."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Touch> Touch(this IProduction<Trigger> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromTrigger.IntoTouch);
        }

        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="Signals.Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Trigger."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Pull."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pull> Pull(this IProduction<Trigger> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromTrigger.IntoPull);
        }

        /// <summary>
        /// Detects when <see cref="Trigger.Touch"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Trigger."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsSatisfiedBy(this IProduction<Trigger> production, INotification<Touch> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenTriggerIs.SatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Trigger.Touch"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Trigger."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsNotSatisfiedBy(this IProduction<Trigger> production, INotification<Touch> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenTriggerIs.NotSatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Trigger.Pull"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Trigger."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsSatisfiedBy(this IProduction<Trigger> production, INotification<Pull> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenTriggerIs.SatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Trigger.Pull"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Trigger."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsNotSatisfiedBy(this IProduction<Trigger> production, INotification<Pull> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenTriggerIs.NotSatisfiedBy(notification));
        }
    }
}
