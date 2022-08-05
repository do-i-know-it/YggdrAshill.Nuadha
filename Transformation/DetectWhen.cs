using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Detects <see cref="Pulse"/> of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public static class DetectWhen<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Consumes <typeparamref name="TSignal"/> to detect <see cref="Pulse"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TSignal> IsConsumed(INotification<TSignal> notification, IConsumption<Pulse> consumption)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new ConsumeToDetect(notification, consumption);
        }
        private sealed class ConsumeToDetect :
            IConsumption<TSignal>
        {
            private readonly INotification<TSignal> notification;

            private readonly IConsumption<Pulse> consumption;

            internal ConsumeToDetect(INotification<TSignal> notification, IConsumption<Pulse> consumption)
            {
                this.notification = notification;

                this.consumption = consumption;
            }

            public void Consume(TSignal signal)
            {
                if (!notification.Notify(signal))
                {
                    return;
                }

                consumption.Consume(Pulse.Instance);
            }
        }

        /// <summary>
        /// Produces <see cref="Pulse"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsProduced(IProduction<TSignal> production, INotification<TSignal> notification)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new ProduceToDetect(production, notification);
        }
        private sealed class ProduceToDetect :
            IProduction<Pulse>
        {
            private readonly IProduction<TSignal> production;

            private readonly INotification<TSignal> notification;

            internal ProduceToDetect(IProduction<TSignal> production, INotification<TSignal> notification)
            {
                this.production = production;

                this.notification = notification;
            }

            public ICancellation Produce(IConsumption<Pulse> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return production.Produce(IsConsumed(notification, consumption));
            }
        }
    }
}
