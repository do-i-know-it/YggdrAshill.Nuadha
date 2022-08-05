using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Pull"/>.
    /// </summary>
    public static class ProductionExtensionForPull
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pull"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pull> IntoPull<TSignal>(this IProduction<TSignal> production, INotification<TSignal> notification)
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

            return production.Convert(Signals.IntoPull.From(notification));
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pull"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="notification">
        /// <see cref="Func{T, TResult}"/> to notify <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static IProduction<Pull> IntoPull<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> notification)
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

            return production.IntoPull(When<TSignal>.Is(notification));
        }

        /// <summary>
        /// Detects when one <see cref="Pull"/> is same as or more than another <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="threshold">
        /// <see cref="IThreshold{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsOver(this IProduction<Pull> production, IThreshold<Pull> threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return production.Detect(WhenPullIs.Over, threshold);
        }

        /// <summary>
        /// Detects when one <see cref="Pull"/> is same as or less than another <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="threshold">
        /// <see cref="IThreshold{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsUnder(this IProduction<Pull> production, IThreshold<Pull> threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return production.Detect(WhenPullIs.Under, threshold);
        }
    }
}
