using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadTracker :
        IIgnition<IHeadTrackerSoftware>
    {
        private readonly PoseTracker pose;

        private readonly IConduction<Space3D.Direction> direction;

        public HeadTracker(PoseTracker pose, IConduction<Space3D.Direction> direction)
        {
            if (pose == null)
            {
                throw new ArgumentNullException(nameof(pose));
            }
            if (direction == null)
            {
                throw new ArgumentNullException(nameof(direction));
            }

            this.pose = pose;

            this.direction = direction;
        }

        public ICancellation Connect(IHeadTrackerSoftware handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var cancelPose = pose.Connect(handler.Pose);

            var cancelDirection = direction.Produce(handler.Direction);

            return new Cancellation(() =>
            {
                cancelPose.Cancel();

                cancelDirection.Cancel();
            });
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
