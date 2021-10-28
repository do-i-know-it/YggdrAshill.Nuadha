using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgnitePoseTracker :
        IIgnition<IPoseTrackerSoftware>
    {
        private readonly ITransmission<Space3D.Position> position;

        private readonly ITransmission<Space3D.Rotation> rotation;

        internal IgnitePoseTracker(PoseTracker protocol, IPoseTrackerConfiguration configuration)
        {
            position = protocol.Position.Transmit(configuration.Position);

            rotation = protocol.Rotation.Transmit(configuration.Rotation);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPoseTrackerSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            var composite = new CompositeCancellation();

            position.Produce(module.Position).Synthesize(composite);
            rotation.Produce(module.Rotation).Synthesize(composite);

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
