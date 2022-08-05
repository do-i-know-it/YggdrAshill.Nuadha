using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Tilt"/>.
    /// </summary>
    public static class ProductionExtensionForTilt
    {
        /// <summary>
        /// Converts <see cref="Tilt.Distance"/> into <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pull> DistanceIntoPull(this IProduction<Tilt> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(TiltInto.PullBy.Distance);
        }

        /// <summary>
        /// Converts <see cref="Tilt.Right"/> into <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pull> RightIntoPull(this IProduction<Tilt> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(TiltInto.PullBy.Right);
        }

        /// <summary>
        /// Converts <see cref="Tilt.Left"/> into <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pull> LeftIntoPull(this IProduction<Tilt> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(TiltInto.PullBy.Left);
        }

        /// <summary>
        /// Converts <see cref="Tilt.Forward"/> into <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pull> ForwardIntoPull(this IProduction<Tilt> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(TiltInto.PullBy.Forward);
        }

        /// <summary>
        /// Converts <see cref="Tilt.Backward"/> into <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pull."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Pull> BackwardIntoPull(this IProduction<Tilt> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(TiltInto.PullBy.Backward);
        }
    }
}
