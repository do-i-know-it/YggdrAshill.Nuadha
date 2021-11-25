using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations to correct <see cref="IPoseTrackerHardware"/> or <see cref="IPoseTrackerSoftware"/>.
    /// </summary>
    public static class PoseTrackerTo
    {
        /// <summary>
        /// Converts <see cref="IPoseTrackerConfiguration"/> into <see cref="IPoseTrackerCorrection"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerCorrection"/> converted from <see cref="IPoseTrackerConfiguration"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerCorrection Calibrate(IPoseTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new PoseTrackerCalibration(configuration);
        }
        private sealed class PoseTrackerCalibration :
            IPoseTrackerCorrection
        {
            internal PoseTrackerCalibration(IPoseTrackerConfiguration configuration)
            {
                Position = Space3DPositionTo.Calibrate(configuration.Position);

                Rotation = Space3DRotationTo.Calibrate(configuration.Rotation);
            }

            public ITranslation<Space3D.Position, Space3D.Position> Position { get; }

            public ITranslation<Space3D.Rotation, Space3D.Rotation> Rotation { get; }
        }
    }
}
