using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
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
        public static IEmission Conduct(this IPoseTrackerSoftware software, IPoseTrackerConfiguration configuration)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return Nuadha.Conduct.PoseTracker(configuration, software);
        }

        public static ITransmission<IPoseTrackerSoftware> Transmit(this IPoseTrackerProtocol protocol, IPoseTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return Nuadha.Transmit.PoseTracker(configuration, protocol);
        }

        public static IConnection<IPoseTrackerHardware> Connect(this IPoseTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return Nuadha.Connect.PoseTracker(software);
        }

        public static IConnection<IPoseTrackerSoftware> Connect(this IPoseTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return Nuadha.Connect.PoseTracker(hardware);
        }

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
