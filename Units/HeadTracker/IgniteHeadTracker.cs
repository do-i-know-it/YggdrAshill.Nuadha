using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class IgniteHeadTracker :
        IIgnition<IHeadTrackerHardwareHandler>
    {
        private readonly IgnitePoseTracker pose;

        private readonly ITransmission<Space3D.Direction> direction;

        internal IgniteHeadTracker(HeadTrackerModule module, IHeadTrackerConfiguration configuration)
        {
            pose = new IgnitePoseTracker(module.Pose, configuration.Pose);

            direction = module.Direction.Transmit(configuration.Direction);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IHeadTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            pose.Connect(handler.Pose).Synthesize(synthesized);
            direction.Produce(handler.Direction).Synthesize(synthesized);

            return synthesized;
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
