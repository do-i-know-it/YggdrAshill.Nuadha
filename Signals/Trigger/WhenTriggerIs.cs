using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
    /// </summary>
    public static class WhenTriggerIs
    {
        /// <summary>
        /// When <see cref="Trigger.Touch"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Trigger> SatisfiedBy(INotification<Touch> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new TriggerTouchIsSatisfiedBy(notification);
        }
        private sealed class TriggerTouchIsSatisfiedBy :
            INotification<Trigger>
        {
            private readonly INotification<Touch> notification;

            internal TriggerTouchIsSatisfiedBy(INotification<Touch> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Trigger signal)
            {
                return notification.Notify(signal.Touch);
            }
        }

        /// <summary>
        /// When <see cref="Trigger.Touch"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Trigger> NotSatisfiedBy(INotification<Touch> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new TriggerTouchIsNotSatisfiedBy(notification);
        }
        private sealed class TriggerTouchIsNotSatisfiedBy :
            INotification<Trigger>
        {
            private readonly INotification<Touch> notification;

            internal TriggerTouchIsNotSatisfiedBy(INotification<Touch> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Trigger signal)
            {
                return !notification.Notify(signal.Touch);
            }
        }

        /// <summary>
        /// When <see cref="Trigger.Pull"/> is notified with <see cref="INotification{TSignal}"/> for <see cref="Pull"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Trigger> SatisfiedBy(INotification<Pull> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new TriggerPullIsSatisfiedBy(notification);
        }
        private sealed class TriggerPullIsSatisfiedBy :
            INotification<Trigger>
        {
            private readonly INotification<Pull> notification;

            internal TriggerPullIsSatisfiedBy(INotification<Pull> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Trigger signal)
            {
                return notification.Notify(signal.Pull);
            }
        }

        /// <summary>
        /// When <see cref="Trigger.Pull"/> is not notified with <see cref="INotification{TSignal}"/> for <see cref="Pull"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Trigger"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<Trigger> NotSatisfiedBy(INotification<Pull> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new TriggerPullIsNotSatisfiedBy(notification);
        }
        private sealed class TriggerPullIsNotSatisfiedBy :
            INotification<Trigger>
        {
            private readonly INotification<Pull> notification;

            internal TriggerPullIsNotSatisfiedBy(INotification<Pull> notification)
            {
                this.notification = notification;
            }

            public bool Notify(Trigger signal)
            {
                return !notification.Notify(signal.Pull);
            }
        }
    }
}
