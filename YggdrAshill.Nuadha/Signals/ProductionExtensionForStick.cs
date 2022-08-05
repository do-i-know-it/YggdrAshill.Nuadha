using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Stick"/>.
    /// </summary>
    public static class ProductionExtensionForStick
    {
        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Touch."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Touch> Touch(this IProduction<Stick> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromStick.IntoTouch);
        }

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Push."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Push> Push(this IProduction<Stick> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromStick.IntoPush);
        }

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Tilt"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Tilt."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Tilt> Tilt(this IProduction<Stick> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromStick.IntoTilt);
        }

        /// <summary>
        /// Detects when <see cref="Stick.Touch"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsSatisfiedBy(this IProduction<Stick> production, INotification<Touch> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenStickIs.SatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Stick.Touch"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsNotSatisfiedBy(this IProduction<Stick> production, INotification<Touch> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenStickIs.NotSatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Stick.Push"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsSatisfiedBy(this IProduction<Stick> production, INotification<Push> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenStickIs.SatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Stick.Push"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsNotSatisfiedBy(this IProduction<Stick> production, INotification<Push> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenStickIs.NotSatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Stick.Tilt"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Tilt"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Tilt"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsSatisfiedBy(this IProduction<Stick> production, INotification<Tilt> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenStickIs.SatisfiedBy(notification));
        }

        /// <summary>
        /// Detects when <see cref="Stick.Tilt"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Signals.Tilt"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Signals.Tilt"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsNotSatisfiedBy(this IProduction<Stick> production, INotification<Tilt> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(WhenStickIs.NotSatisfiedBy(notification));
        }
    }
}
