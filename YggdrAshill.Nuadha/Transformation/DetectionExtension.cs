using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    public static class DetectionExtension
    {
        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Notice"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, INotification<TSignal> notification)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return ProduceSignalTo.Detect(production, notification);
        }

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="notification">
        /// <see cref="Func{T, TResult}"/> to detect <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Notice"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> notification)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return production.Detect(NoticeOf.Signal(notification));
        }

        /// <summary>
        /// Sends <see cref="Notice"/> to <see cref="Action"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to send <see cref="Notice"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action"/> to receive <see cref="Notice"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Produce(this IProduction<Notice> production, Action consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumption.Invoke();
            });
        }
    }
}
