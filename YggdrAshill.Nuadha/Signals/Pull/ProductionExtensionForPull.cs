using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
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
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pull"/> like <paramref name="conversion"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TSignal"/> into <see cref="float"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IProduction<Pull> IntoPull<TSignal>(this IProduction<TSignal> production, Func<TSignal, float> conversion)
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

            return production.Convert(IntoPullFrom<TSignal>.Like(conversion));
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pull"/> like <paramref name="conversion"/>.
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
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IProduction<Pull> IntoPull<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> conversion)
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

            return production.Convert(IntoPullFrom<TSignal>.Like(conversion));
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
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IProduction<Pull> IntoPull<TSignal>(this IProduction<TSignal> production, IDetection<TSignal> detection)
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

            return production.Convert(IntoPullFrom<TSignal>.When(detection));
        }

        /// <summary>
        /// Detects when one <see cref="Pull"/> is equal to another <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Pull"/>.
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
        public static IProduction<Pulse> IsEqualTo(this IProduction<Pull> production, ITarget<Pull> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(PullIs.EqualTo, target);
        }

        /// <summary>
        /// Detects when one <see cref="Pull"/> is not equal to another <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Pull"/>.
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
        public static IProduction<Pulse> IsNotEqualTo(this IProduction<Pull> production, ITarget<Pull> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(PullIs.NotEqualTo, target);
        }

        /// <summary>
        /// Detects when one <see cref="Pull"/> is more than another <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Pull"/>.
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
        public static IProduction<Pulse> IsMoreThan(this IProduction<Pull> production, ITarget<Pull> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(PullIs.MoreThan, target);
        }

        /// <summary>
        /// Detects when one <see cref="Pull"/> is less than another <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Pull"/>.
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
        public static IProduction<Pulse> IsLessThan(this IProduction<Pull> production, ITarget<Pull> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(PullIs.LessThan, target);
        }

        /// <summary>
        /// Detects when one <see cref="Pull"/> is another <see cref="Pull"/> or more.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Pull"/>.
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
        public static IProduction<Pulse> IsOver(this IProduction<Pull> production, ITarget<Pull> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(PullIs.Over, target);
        }

        /// <summary>
        /// Detects when one <see cref="Pull"/> is another <see cref="Pull"/> or less.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Pull"/>.
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
        public static IProduction<Pulse> IsUnder(this IProduction<Pull> production, ITarget<Pull> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(PullIs.Under, target);
        }

        /// <summary>
        /// Sends <see cref="Pull"/> like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <see cref="Pull"/> as <see cref="float"/>.
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
        public static ICancellation Send(this IProduction<Pull> production, Action<float> consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(ConsumePull.Like(consumption));
        }
    }
}
