using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="HeadTracker"/>.
    /// </summary>
    public static class HeadTrackerExtension
    {
        /// <summary>
        /// Converts <see cref="HeadTracker"/> into <see cref="IIgnition{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="HeadTracker"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHeadTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IHeadTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IHeadTrackerSoftware> Ignite(this HeadTracker protocol, IHeadTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteHeadTracker(protocol, configuration);
        }
        private sealed class IgniteHeadTracker :
            IIgnition<IHeadTrackerSoftware>
        {
            private readonly IIgnition<IPoseTrackerSoftware> pose;

            private readonly ITransmission<Space3D.Direction> direction;

            internal IgniteHeadTracker(HeadTracker protocol, IHeadTrackerConfiguration configuration)
            {
                pose = protocol.Pose.Ignite(configuration.Pose);

                direction = protocol.Direction.Ignite(configuration.Direction);
            }

            public ICancellation Connect(IHeadTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                pose.Connect(module.Pose).Synthesize(composite);
                direction.Produce(module.Direction).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                pose.Emit();

                direction.Emit();
            }

            public void Dispose()
            {
                pose.Dispose();

                direction.Dispose();
            }
        }
    }
}
