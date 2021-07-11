using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class PoseTracker :
        IPoseTracker
    {
        public ITransmission<Space3D.Position> Position { get; }

        public ITransmission<Space3D.Rotation> Rotation { get; }

        internal PoseTracker(IPoseTrackerModule module, IPoseTrackerConfiguration configuration)
        {
            Position = module.Position.Transmit(configuration.Position);

            Rotation = module.Rotation.Transmit(configuration.Rotation);
        }
    }
}
