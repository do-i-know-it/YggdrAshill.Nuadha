using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Push"/>.
    /// </summary>
    public static class ProductionExtensionForPush
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Push"/> like <paramref name="conversion"/>.
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
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IProduction<Push> IntoPush<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> conversion)
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

            return production.Convert(IntoPushFrom<TSignal>.Like(conversion));
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Push"/>.
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
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IProduction<Push> IntoPush<TSignal>(this IProduction<TSignal> production, IDetection<TSignal> detection)
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

            return production.Convert(IntoPushFrom<TSignal>.When(detection));
        }

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Touch."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Touch> IntoTouch(this IProduction<Push> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromPush.IntoTouch);
        }

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pull> IntoPull(this IProduction<Push> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromPush.IntoPull);
        }

        /// <summary>
        /// Detects when <see cref="Push"/> is <see cref="Push.Enabled"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsEnabled(this IProduction<Push> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Detect(PushIs.Enabled);
        }

        /// <summary>
        /// Detects when <see cref="Push"/> is <see cref="Push.Disabled"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pulse> IsDisabled(this IProduction<Push> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Detect(PushIs.Disabled);
        }

        /// <summary>
        /// Detects when one <see cref="Push"/> is equal to another <see cref="Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Push"/>.
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
        public static IProduction<Pulse> IsEqualTo(this IProduction<Push> production, ITarget<Push> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(PushIs.EqualTo, target);
        }

        /// <summary>
        /// Detects when one <see cref="Push"/> is not equal to another <see cref="Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Push"/>.
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
        public static IProduction<Pulse> IsNotEqualTo(this IProduction<Push> production, ITarget<Push> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(PushIs.NotEqualTo, target);
        }

        /// <summary>
        /// Sends <see cref="Push"/> like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Push"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <see cref="Push"/> as <see cref="bool"/>.
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
        public static ICancellation Send(this IProduction<Push> production, Action<bool> consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(ConsumePush.Like(consumption));
        }
    }
}
