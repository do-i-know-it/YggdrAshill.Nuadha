using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    public static class ConsumeSignalTo
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
        /// </typeparam>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to consume <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> to consume <typeparamref name="TInput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TInput> Convert<TInput, TOutput>(ITranslation<TInput, TOutput> translation, IConsumption<TOutput> consumption)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new ConsumeToConvert<TInput, TOutput>(translation, consumption);
        }
        private sealed class ConsumeToConvert<TInput, TOutput> :
            IConsumption<TInput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly ITranslation<TInput, TOutput> translation;

            private readonly IConsumption<TOutput> consumption;

            internal ConsumeToConvert(ITranslation<TInput, TOutput> translation, IConsumption<TOutput> consumption)
            {
                this.translation = translation;

                this.consumption = consumption;
            }

            public void Consume(TInput signal)
            {
                var translated = translation.Translate(signal);

                consumption.Consume(translated);
            }
        }

        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> to detect.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Notice"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> to consume <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TSignal> Detect<TSignal>(INotification<TSignal> notification, IConsumption<Notice> consumption)
            where TSignal : ISignal
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new ConsumeToDetect<TSignal>(notification, consumption);
        }
        private sealed class ConsumeToDetect<TSignal> :
            IConsumption<TSignal>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> notification;

            private readonly IConsumption<Notice> consumption;

            internal ConsumeToDetect(INotification<TSignal> notification, IConsumption<Notice> consumption)
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

                consumption.Consume(Notice.Instance);
            }
        }
    }
}
