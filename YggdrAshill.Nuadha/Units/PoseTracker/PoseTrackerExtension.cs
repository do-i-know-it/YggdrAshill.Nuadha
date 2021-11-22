using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPoseTrackerHardware"/> and <see cref="IPoseTrackerSoftware"/>.
    /// </summary>
    public static class PoseTrackerExtension
    {
        /// <summary>
        /// Calibrates <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IPoseTrackerHardware"/> to calibrate.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to calibrate.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerSoftware"/> calibrated.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerHardware Calibrate(this IPoseTrackerHardware module, IPoseTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new CalibratedPoseTrackerHardware(module, configuration);
        }
        private sealed class CalibratedPoseTrackerHardware :
            IPoseTrackerHardware
        {
            internal CalibratedPoseTrackerHardware(IPoseTrackerHardware module, IPoseTrackerConfiguration configuration)
            {
                Position = ConvertTo.Produce(module.Position, Space3DPositionTo.Calibrate(configuration.Position));

                Rotation = ConvertTo.Produce(module.Rotation, Space3DRotationTo.Calibrate(configuration.Rotation));
            }

            public IProduction<Space3D.Position> Position { get; }

            public IProduction<Space3D.Rotation> Rotation { get; }
        }
    }
}
