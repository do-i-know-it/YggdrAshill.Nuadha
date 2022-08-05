using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="INotification{TSignal}"/> to operate <see cref="INotification{TSignal}"/>.
    /// </summary>
    public static class NotificationExtension
    {
        public static INotification<TSignal> Not<TSignal>(this INotification<TSignal> notification)
            where TSignal : ISignal
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return Notify<TSignal>.Inverted(notification);
        }
        
        public static INotification<TSignal> And<TSignal>(this INotification<TSignal> first, INotification<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return Notify<TSignal>.Multiplied(first, second);
        }

        public static INotification<TSignal> And<TSignal>(this INotification<TSignal> first, Func<TSignal, bool> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return first.And(When<TSignal>.Is(second));
        }

        public static INotification<TSignal> Or<TSignal>(this INotification<TSignal> first, INotification<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return Notify<TSignal>.Added(first, second);
        }

        public static INotification<TSignal> Or<TSignal>(this INotification<TSignal> first, Func<TSignal, bool> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return first.Or(When<TSignal>.Is(second));
        }
    }
}
