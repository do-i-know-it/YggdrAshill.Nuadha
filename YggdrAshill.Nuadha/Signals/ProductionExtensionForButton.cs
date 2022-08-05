using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Button"/>.
    /// </summary>
    public static class ProductionExtensionForButton
    {
        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Touch."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Touch> Touch(this IProduction<Button> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromButton.IntoTouch);
        }

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Push."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Push> Push(this IProduction<Button> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromButton.IntoPush);
        }

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Signals.Trigger"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Trigger."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Trigger> Trigger(this IProduction<Button> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromButton.IntoTrigger);
        }

        /// <summary>
        /// Detects when <see cref="Button.Touch"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsSatisfiedBy(this IProduction<Button> production, INotification<Touch> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenButtonIs.SatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Button.Touch"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsNotSatisfiedBy(this IProduction<Button> production, INotification<Touch> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenButtonIs.NotSatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Button.Push"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsSatisfiedBy(this IProduction<Button> production, INotification<Push> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenButtonIs.SatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Button.Push"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsNotSatisfiedBy(this IProduction<Button> production, INotification<Push> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenButtonIs.NotSatisfiedBy(notification));
        }
    }
}
