using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Stick"/>.
    /// </summary>
    public static class ProductionExtensionForStick
    {
        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Touch."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Touch> Touch(this IProduction<Stick> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromStick.IntoTouch);
        }

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Push."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Push> Push(this IProduction<Stick> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromStick.IntoPush);
        }

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Tilt"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Stick."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Tilt."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Tilt> Tilt(this IProduction<Stick> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromStick.IntoTilt);
        }
    }
}
