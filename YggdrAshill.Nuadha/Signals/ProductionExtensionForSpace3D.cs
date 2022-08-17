using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
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
        /// <param name="error">
        /// <see cref="IError{TSignal}"/> for <see cref="Space3D.Position"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Position"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="error"/> is null.
        /// </exception>
        public static IProduction<Space3D.Position> Calibrate(this IProduction<Space3D.Position> production, IError<Space3D.Position> error)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            return production.Convert(ToCalibrateSpace3D.PositionWith, error);
        }

        /// <summary>
        /// Calibrates <see cref="Space3D.Rotation"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Rotation"/>.
        /// </param>
        /// <param name="error">
        /// <see cref="IError{TSignal}"/> for <see cref="Space3D.Rotation"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Rotation"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="error"/> is null.
        /// </exception>
        public static IProduction<Space3D.Rotation> Calibrate(this IProduction<Space3D.Rotation> production, IError<Space3D.Rotation> error)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            return production.Convert(ToCalibrateSpace3D.RotationWith, error);
        }

        /// <summary>
        /// Calibrates <see cref="Space3D.Pose"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Pose"/>.
        /// </param>
        /// <param name="error">
        /// <see cref="IError{TSignal}"/> for <see cref="Space3D.Pose"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Space3D.Pose"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="error"/> is null.
        /// </exception>
        public static IProduction<Space3D.Pose> Calibrate(this IProduction<Space3D.Pose> production, IError<Space3D.Pose> error)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            return production.Convert(ToCalibrateSpace3D.PoseWith, error);
        }
    }
}
