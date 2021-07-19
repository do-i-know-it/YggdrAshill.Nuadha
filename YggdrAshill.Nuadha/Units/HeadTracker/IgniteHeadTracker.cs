using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteHeadTracker :
        IIgnition<IHeadTrackerHardwareHandler>
    {
        private readonly IgnitePoseTracker pose;

        private readonly ITransmission<Space3D.Direction> direction;

        internal IgniteHeadTracker(HeadTrackerModule module, IHeadTrackerConfiguration configuration)
        {
            pose = new IgnitePoseTracker(module.Pose, configuration.Pose);

            direction = module.Direction.ToTransmit(configuration.Direction);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IHeadTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var composite = new CompositeCancellation();

            pose.Connect(handler.Pose).Synthesize(composite);
            direction.Produce(handler.Direction).Synthesize(composite);

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
