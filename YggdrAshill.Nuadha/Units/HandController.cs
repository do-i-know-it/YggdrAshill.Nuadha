using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HandController :
        IIgnition<IHandControllerSoftware>
    {
        private readonly PoseTracker pose;

        private readonly Stick thumb;

        private readonly Trigger indexFinger;

        private readonly Trigger handGrip;

        public HandController(PoseTracker pose, Stick thumb, Trigger indexFinger, Trigger handGrip)
        {
            if (pose == null)
            {
                throw new ArgumentNullException(nameof(pose));
            }
            if (thumb == null)
            {
                throw new ArgumentNullException(nameof(thumb));
            }
            if (indexFinger == null)
            {
                throw new ArgumentNullException(nameof(indexFinger));
            }
            if (handGrip == null)
            {
                throw new ArgumentNullException(nameof(handGrip));
            }

            this.pose = pose;

            this.thumb = thumb;

            this.indexFinger = indexFinger;

            this.handGrip = handGrip;
        }

        public ICancellation Connect(IHandControllerSoftware handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var cancelPose = pose.Connect(handler.Pose);

            var cancelThumb = thumb.Connect(handler.Thumb);

            var cancelIndexFinger = indexFinger.Connect(handler.IndexFinger);

            var cancelHandGrip = handGrip.Connect(handler.HandGrip);


            return new Cancellation(() =>
            {
                cancelPose.Cancel();

                cancelThumb.Cancel();

                cancelIndexFinger.Cancel();

                cancelHandGrip.Cancel();
            });
        }

        public void Emit()
        {
            pose.Emit();

            thumb.Emit();

            indexFinger.Emit();

            handGrip.Emit();
        }

        public void Dispose()
        {
            pose.Dispose();

            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }
    }
}
