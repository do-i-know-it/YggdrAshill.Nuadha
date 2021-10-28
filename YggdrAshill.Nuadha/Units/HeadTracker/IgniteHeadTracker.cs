using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteHeadTracker :
        IIgnition<IHeadTrackerSoftware>
    {
        private readonly IgnitePoseTracker pose;

        private readonly ITransmission<Space3D.Direction> direction;

        internal IgniteHeadTracker(HeadTracker protocol, IHeadTrackerConfiguration configuration)
        {
            pose = new IgnitePoseTracker(protocol.Pose, configuration.Pose);

            direction = protocol.Direction.Transmit(configuration.Direction);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void Emit()
        {
            pose.Emit();

            direction.Emit();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            pose.Dispose();

            direction.Dispose();
        }
    }
}
