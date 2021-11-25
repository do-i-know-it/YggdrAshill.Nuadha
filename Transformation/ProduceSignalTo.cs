using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="IProduction{TSignal}"/> for Transformation.
    /// </summary>
    public static class ProduceSignalTo
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
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IProduction<TOutput> Convert<TInput, TOutput>(IProduction<TInput> production, ITranslation<TInput, TOutput> translation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production is null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (translation is null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new ProduceToConvert<TInput, TOutput>(production, translation);
        }
        private sealed class ProduceToConvert<TInput, TOutput> :
            IProduction<TOutput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly IProduction<TInput> production;

            private readonly ITranslation<TInput, TOutput> translation;

            internal ProduceToConvert(IProduction<TInput> production, ITranslation<TInput, TOutput> translation)
            {
                this.production = production;

                this.translation = translation;
            }

            public ICancellation Produce(IConsumption<TOutput> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return production.Produce(ConsumeSignalTo.Convert(translation, consumption));
            }
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
        /// <see cref="INotification{TSignal}"/> to detect <typeparamref name="TSignal"/>.
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
        public static IProduction<Notice> Detect<TSignal>(IProduction<TSignal> production, INotification<TSignal> notification)
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

            return new ProduceToDetect<TSignal>(production, notification);
        }
        private sealed class ProduceToDetect<TSignal> :
            IProduction<Notice>
            where TSignal : ISignal
        {
            private readonly IProduction<TSignal> production;

            private readonly INotification<TSignal> notification;

            internal ProduceToDetect(IProduction<TSignal> production, INotification<TSignal> notification)
            {
                this.production = production;

                this.notification = notification;
            }

            public ICancellation Produce(IConsumption<Notice> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return production.Produce(ConsumeSignalTo.Detect(notification, consumption));
            }
        }
    }
}
