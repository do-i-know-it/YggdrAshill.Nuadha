using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
    /// </summary>
    public static class WhenButtonIs
    {
        /// <summary>
        /// When <see cref="Button.Touch"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Button> SatisfiedBy(INotification<Touch> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new ButtonTouchIsSatisfiedBy(notification);
        }
        private sealed class ButtonTouchIsSatisfiedBy :
            INotification<Button>
        {
            private readonly INotification<Touch> notification;

            internal ButtonTouchIsSatisfiedBy(INotification<Touch> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Button signal)
            {
                return notification.Notify(signal.Touch);
            }
        }

        /// <summary>
        /// When <see cref="Button.Touch"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Button> NotSatisfiedBy(INotification<Touch> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new ButtonTouchIsNotSatisfiedBy(notification);
        }
        private sealed class ButtonTouchIsNotSatisfiedBy :
            INotification<Button>
        {
            private readonly INotification<Touch> notification;

            internal ButtonTouchIsNotSatisfiedBy(INotification<Touch> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Button signal)
            {
                return !notification.Notify(signal.Touch);
            }
        }

        /// <summary>
        /// When <see cref="Button.Push"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Button> SatisfiedBy(INotification<Push> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new ButtonPushIsSatisfiedBy(notification);
        }
        private sealed class ButtonPushIsSatisfiedBy :
            INotification<Button>
        {
            private readonly INotification<Push> notification;

            internal ButtonPushIsSatisfiedBy(INotification<Push> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Button signal)
            {
                return notification.Notify(signal.Push);
            }
        }

        /// <summary>
        /// When <see cref="Button.Push"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Button"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Button> NotSatisfiedBy(INotification<Push> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new ButtonPushIsNotSatisfiedBy(notification);
        }
        private sealed class ButtonPushIsNotSatisfiedBy :
            INotification<Button>
        {
            private readonly INotification<Push> notification;

            internal ButtonPushIsNotSatisfiedBy(INotification<Push> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Button signal)
            {
                return !notification.Notify(signal.Push);
            }
        }
    }
}
