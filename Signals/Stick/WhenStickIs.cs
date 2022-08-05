using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
    /// </summary>
    public static class WhenStickIs
    {
        /// <summary>
        /// When <see cref="Stick.Touch"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Stick> SatisfiedBy(INotification<Touch> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new StickTouchIsSatisfiedBy(notification);
        }
        private sealed class StickTouchIsSatisfiedBy :
            INotification<Stick>
        {
            private readonly INotification<Touch> notification;

            internal StickTouchIsSatisfiedBy(INotification<Touch> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Stick signal)
            {
                return notification.Notify(signal.Touch);
            }
        }

        /// <summary>
        /// When <see cref="Stick.Touch"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Stick> NotSatisfiedBy(INotification<Touch> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new StickTouchIsNotSatisfiedBy(notification);
        }
        private sealed class StickTouchIsNotSatisfiedBy :
            INotification<Stick>
        {
            private readonly INotification<Touch> notification;

            internal StickTouchIsNotSatisfiedBy(INotification<Touch> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Stick signal)
            {
                return !notification.Notify(signal.Touch);
            }
        }

        /// <summary>
        /// When <see cref="Stick.Push"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Stick> SatisfiedBy(INotification<Push> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new StickPushIsSatisfiedBy(notification);
        }
        private sealed class StickPushIsSatisfiedBy :
            INotification<Stick>
        {
            private readonly INotification<Push> notification;

            internal StickPushIsSatisfiedBy(INotification<Push> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Stick signal)
            {
                return notification.Notify(signal.Push);
            }
        }

        /// <summary>
        /// When <see cref="Stick.Push"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Stick> NotSatisfiedBy(INotification<Push> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new StickPushIsNotSatisfiedBy(notification);
        }
        private sealed class StickPushIsNotSatisfiedBy :
            INotification<Stick>
        {
            private readonly INotification<Push> notification;

            internal StickPushIsNotSatisfiedBy(INotification<Push> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Stick signal)
            {
                return !notification.Notify(signal.Push);
            }
        }

        /// <summary>
        /// When <see cref="Stick.Tilt"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Tilt"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Tilt"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Stick> SatisfiedBy(INotification<Tilt> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new StickTiltIsSatisfiedBy(notification);
        }
        private sealed class StickTiltIsSatisfiedBy :
            INotification<Stick>
        {
            private readonly INotification<Tilt> notification;

            internal StickTiltIsSatisfiedBy(INotification<Tilt> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Stick signal)
            {
                return notification.Notify(signal.Tilt);
            }
        }

        /// <summary>
        /// When <see cref="Stick.Tilt"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Tilt"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Tilt"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Stick"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Stick> NotSatisfiedBy(INotification<Tilt> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new StickTiltIsNotSatisfiedBy(notification);
        }
        private sealed class StickTiltIsNotSatisfiedBy :
            INotification<Stick>
        {
            private readonly INotification<Tilt> notification;

            internal StickTiltIsNotSatisfiedBy(INotification<Tilt> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Stick signal)
            {
                return !notification.Notify(signal.Tilt);
            }
        }
    }
}
