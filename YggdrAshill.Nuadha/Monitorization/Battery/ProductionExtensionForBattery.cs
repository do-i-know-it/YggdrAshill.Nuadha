using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Monitorization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Battery"/>.
    /// </summary>
    public static class ProductionExtensionForBattery
    {
        /// <summary>
        /// Converts <see cref="Battery"/> into <see cref="Note"/> in ratio.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Note> NoteInRatio(this IProduction<Battery> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromBattery.IntoNoteIn.Ratio);
        }

        /// <summary>
        /// Converts <see cref="Battery"/> into <see cref="Note"/> in percent.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<Note> NoteInPercent(this IProduction<Battery> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return production.Convert(FromBattery.IntoNoteIn.Percent);
        }

        /// <summary>
        /// Detects when one <see cref="Battery"/> is equal to another <see cref="Battery"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Battery"/>.
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
        public static IProduction<Pulse> IsEqualTo(this IProduction<Battery> production, ITarget<Battery> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(BatteryIs.EqualTo, target);
        }

        /// <summary>
        /// Detects when one <see cref="Battery"/> is not equal to another <see cref="Battery"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Battery"/>.
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
        public static IProduction<Pulse> IsNotEqualTo(this IProduction<Battery> production, ITarget<Battery> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(BatteryIs.NotEqualTo, target);
        }

        /// <summary>
        /// Detects when one <see cref="Battery"/> is more than another <see cref="Battery"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Battery"/>.
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
        public static IProduction<Pulse> IsMoreThan(this IProduction<Battery> production, ITarget<Battery> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(BatteryIs.MoreThan, target);
        }

        /// <summary>
        /// Detects when one <see cref="Battery"/> is less than another <see cref="Battery"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Battery"/>.
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
        public static IProduction<Pulse> IsLessThan(this IProduction<Battery> production, ITarget<Battery> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(BatteryIs.LessThan, target);
        }

        /// <summary>
        /// Detects when one <see cref="Battery"/> is another <see cref="Battery"/> or more.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Battery"/>.
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
        public static IProduction<Pulse> IsOver(this IProduction<Battery> production, ITarget<Battery> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(BatteryIs.Over, target);
        }

        /// <summary>
        /// Detects when one <see cref="Battery"/> is another <see cref="Battery"/> or less.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <param name="target">
        /// <see cref="ITarget{TSignal}"/> for <see cref="Battery"/>.
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
        public static IProduction<Pulse> IsUnder(this IProduction<Battery> production, ITarget<Battery> target)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return production.Detect(BatteryIs.Under, target);
        }

        /// <summary>
        /// Sends <see cref="Battery"/> like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Battery"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <see cref="Battery"/> as <see cref="float"/>.
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
        public static ICancellation Send(this IProduction<Battery> production, Action<float> consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(ConsumeBattery.Like(consumption));
        }
    }
}
