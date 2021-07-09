using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
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

            var synthesized = new SynthesizedCancellation();

            position.Produce(handler.Position).Synthesize(synthesized);
            rotation.Produce(handler.Rotation).Synthesize(synthesized);

            return synthesized;
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
