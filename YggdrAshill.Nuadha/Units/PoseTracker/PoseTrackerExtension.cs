using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="PoseTracker"/>.
    /// </summary>
    public static class PoseTrackerExtension
    {
        /// <summary>
        /// Converts <see cref="PoseTracker"/> into <see cref="IIgnition{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="PoseTracker"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IPoseTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IPoseTrackerSoftware> Ignite(this PoseTracker protocol, IPoseTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgnitePoseTracker(protocol, configuration);
        }
        private sealed class IgnitePoseTracker :
            IIgnition<IPoseTrackerSoftware>
        {
            private readonly ITransmission<Space3D.Position> position;

            private readonly ITransmission<Space3D.Rotation> rotation;

            internal IgnitePoseTracker(PoseTracker protocol, IPoseTrackerConfiguration configuration)
            {
                position = protocol.Position.Transmit(configuration.Position);

                rotation = protocol.Rotation.Transmit(configuration.Rotation);
            }

            public ICancellation Connect(IPoseTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                position.Produce(module.Position).Synthesize(composite);
                rotation.Produce(module.Rotation).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                position.Emit();

                rotation.Emit();
            }

            public void Dispose()
            {
                position.Dispose();

                rotation.Dispose();
            }
        }

        /// <summary>
        /// Converts <see cref="IPoseTrackerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IPoseTrackerHardware"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPoseTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IConnection<IPoseTrackerSoftware> Convert(this IPoseTrackerHardware module, IPoseTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectCalibratedPoseTracker(module, configuration);
        }
        private sealed class ConnectCalibratedPoseTracker :
            IConnection<IPoseTrackerSoftware>
        {
            private readonly IProduction<Space3D.Position> position;

            private readonly IProduction<Space3D.Rotation> rotation;

            internal ConnectCalibratedPoseTracker(IPoseTrackerHardware module, IPoseTrackerConfiguration configuration)
            {
                position = module.Position.Convert(ToCorrectSpace3D.PositionTo.Calibrate(configuration.Position));

                rotation = module.Rotation.Convert(ToCorrectSpace3D.RotationTo.Calibrate(configuration.Rotation));
            }

            public ICancellation Connect(IPoseTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                position.Produce(module.Position).Synthesize(composite);
                rotation.Produce(module.Rotation).Synthesize(composite);

                return composite;
            }
        }
    }
}
