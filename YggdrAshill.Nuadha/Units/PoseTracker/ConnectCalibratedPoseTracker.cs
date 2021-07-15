using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectCalibratedPoseTracker :
        IConnection<IPoseTrackerHardwareHandler>
    {
        private readonly IProduction<Space3D.Position> position;

        private readonly IProduction<Space3D.Rotation> rotation;

        internal ConnectCalibratedPoseTracker(IPoseTrackerSoftwareHandler handler, IPoseTrackerConfiguration configuration)
        {
            position = handler.Position.Convert(ToCorrect.Space3D.PositionTo.Calibrate(configuration.Position));

            rotation = handler.Rotation.Convert(ToCorrect.Space3D.RotationTo.Calibrate(configuration.Rotation));
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
