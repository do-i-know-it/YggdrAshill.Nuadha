using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgnitePoseTracker :
        IIgnition<IPoseTrackerHardwareHandler>
    {
        private readonly ITransmission<Space3D.Position> position;

        private readonly ITransmission<Space3D.Rotation> rotation;

        internal IgnitePoseTracker(PoseTrackerModule module, IPoseTrackerConfiguration configuration)
        {
            position = module.Position.Transmit(configuration.Position);

            rotation = module.Rotation.Transmit(configuration.Rotation);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPoseTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var composite = new CompositeCancellation();

            position.Produce(handler.Position).Synthesize(composite);
            rotation.Produce(handler.Rotation).Synthesize(composite);

            return composite;
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
