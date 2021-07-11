using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class ConnectCalibratedPoseTracker :
        IConnection<IPoseTrackerHardwareHandler>
    {
        private readonly IProduction<Space3D.Position> position;

        private readonly IProduction<Space3D.Rotation> rotation;

        internal ConnectCalibratedPoseTracker(IPoseTrackerSoftwareHandler handler, IPoseTrackerConfiguration configuration)
        {
            position = handler.Position.Convert(Space3D.PositionInto.Position(configuration.Position));

            rotation = handler.Rotation.Convert(Space3D.RotationInto.Rotation(configuration.Rotation));
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
    }
}
