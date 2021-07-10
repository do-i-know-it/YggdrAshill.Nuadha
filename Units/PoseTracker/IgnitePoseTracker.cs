using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class IgnitePoseTracker :
        IIgnition<IPoseTrackerHardwareHandler>
    {
        private readonly ITransmission<Space3D.Position> position;

        private readonly ITransmission<Space3D.Rotation> rotation;

        internal IgnitePoseTracker(IPoseTracker device)
        {
            position = device.Position;

            rotation = device.Rotation;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void Emit()
        {
            position.Emit();

            rotation.Emit();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            position.Dispose();

            rotation.Dispose();
        }
    }
}
