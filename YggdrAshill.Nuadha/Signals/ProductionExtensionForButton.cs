using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Button"/>.
    /// </summary>
    public static class ProductionExtensionForButton
    {
        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Touch."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Touch> Touch(this IProduction<Button> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromButton.IntoTouch);
        }

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Push."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Push> Push(this IProduction<Button> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromButton.IntoPush);
        }

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Signals.Trigger"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Button."/>
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Signals.Trigger."/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Trigger> Trigger(this IProduction<Button> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromButton.IntoTrigger);
        }
    }
}
