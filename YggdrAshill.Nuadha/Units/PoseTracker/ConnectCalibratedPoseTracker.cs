using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectCalibratedPoseTracker :
        IConnection<IPoseTrackerSoftware>
    {
        private readonly IProduction<Space3D.Position> position;

        private readonly IProduction<Space3D.Rotation> rotation;

        internal ConnectCalibratedPoseTracker(IPoseTrackerHardware module, IPoseTrackerConfiguration configuration)
        {
            position = module.Position.Convert(ToCorrectSpace3D.PositionTo.Calibrate(configuration.Position));

            rotation = module.Rotation.Convert(ToCorrectSpace3D.RotationTo.Calibrate(configuration.Rotation));
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
    }
}
