using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> of <see cref="Space3D"/>.
    /// </summary>
    public static class ProductionExtensionForSpace3D
    {
        /// <summary>
        /// Calibrates <see cref="Space3D.Position"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Position"/>.
        /// </param>
        /// <param name="offset">
        /// <see cref="IOffset{TSignal}"/> for <see cref="Space3D.Position"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Position"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="offset"/> is null.
        /// </exception>
        public static IProduction<Space3D.Position> Calibrate(this IProduction<Space3D.Position> production, IOffset<Space3D.Position> offset)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (offset == null)
            {
                throw new ArgumentNullException(nameof(offset));
            }

            return production.Correct(FromSpace3D.PositionInto.PositionWith, offset);
        }

        /// <summary>
        /// Calibrates <see cref="Space3D.Rotation"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Rotation"/>.
        /// </param>
        /// <param name="offset">
        /// <see cref="IOffset{TSignal}"/> for <see cref="Space3D.Rotation"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Rotation"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="offset"/> is null.
        /// </exception>
        public static IProduction<Space3D.Rotation> Calibrate(this IProduction<Space3D.Rotation> production, IOffset<Space3D.Rotation> offset)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (offset == null)
            {
                throw new ArgumentNullException(nameof(offset));
            }

            return production.Correct(FromSpace3D.RotationInto.RotationWith, offset);
        }

        /// <summary>
        /// Calibrates <see cref="Space3D.Pose"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Pose"/>.
        /// </param>
        /// <param name="offset">
        /// <see cref="IOffset{TSignal}"/> for <see cref="Space3D.Pose"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Pose"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="offset"/> is null.
        /// </exception>
        public static IProduction<Space3D.Pose> Calibrate(this IProduction<Space3D.Pose> production, IOffset<Space3D.Pose> offset)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (offset == null)
            {
                throw new ArgumentNullException(nameof(offset));
            }

            return production.Correct(FromSpace3D.PoseInto.PoseWith, offset);
        }
    }
}
