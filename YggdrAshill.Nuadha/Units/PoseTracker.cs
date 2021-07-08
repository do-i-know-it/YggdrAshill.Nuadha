using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTracker :
        IIgnition<IPoseTrackerSoftware>
    {
        private readonly IConduction<Space3D.Position> position;

        private readonly IConduction<Space3D.Rotation> rotation;

        public PoseTracker(IConduction<Space3D.Position> position, IConduction<Space3D.Rotation> rotation)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            if (rotation == null)
            {
                throw new ArgumentNullException(nameof(rotation));
            }

            this.position = position;

            this.rotation = rotation;
        }

        public ICancellation Connect(IPoseTrackerSoftware handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var cancelPosition = position.Produce(handler.Position);

            var cancelRotation = rotation.Produce(handler.Rotation);

            return new Cancellation(() =>
            {
                cancelPosition.Cancel();

                cancelRotation.Cancel();
            });
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
}
