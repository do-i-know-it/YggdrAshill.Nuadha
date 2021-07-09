using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PoseTracker :
        IIgnition<IPoseTrackerHardwareHandler>
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

        public ICancellation Connect(IPoseTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return position.Produce(handler.Position)
                .Synthesize(rotation.Produce(handler.Rotation));
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
