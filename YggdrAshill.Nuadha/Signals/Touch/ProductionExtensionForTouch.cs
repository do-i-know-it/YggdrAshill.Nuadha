using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Touch"/>.
    /// </summary>
    public static class ProductionExtensionForTouch
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Touch"/> like <paramref name="conversion"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TSignal"/> into <see cref="bool"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IProduction<Touch> IntoTouch<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> conversion)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return production.Convert(IntoTouchFrom<TSignal>.Like(conversion));
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Touch"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IProduction<Touch> IntoTouch<TSignal>(this IProduction<TSignal> production, IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return production.Convert(IntoTouchFrom<TSignal>.When(detection));
        }

        /// <summary>
        /// Detects when <see cref="Touch"/> is <see cref="Touch.Enabled"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsEnabled(this IProduction<Touch> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Detect(TouchIs.Enabled);
        }

        /// <summary>
        /// Detects when <see cref="Touch"/> is <see cref="Touch.Disabled"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsDisabled(this IProduction<Touch> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Detect(TouchIs.Disabled);
        }

        /// <summary>
        /// Detects when one <see cref="Touch"/> is equal to another <see cref="Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="target"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsEqualTo(this IProduction<Touch> production, ITarget<Touch> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(TouchIs.EqualTo, target);
        }

        /// <summary>
        /// Detects when one <see cref="Touch"/> is not equal to another <see cref="Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="target"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsNotEqualTo(this IProduction<Touch> production, ITarget<Touch> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(TouchIs.NotEqualTo, target);
        }

        /// <summary>
        /// Sends <see cref="Touch"/> like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Touch"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <see cref="Touch"/> as <see cref="bool"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancell sending.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Send(this IProduction<Touch> production, Action<bool> consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(ConsumeTouch.Like(consumption));
        }
    }
}
