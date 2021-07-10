using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    internal sealed class PoseTracker :
        IPoseTracker
    {
        public ITransmission<Space3D.Position> Position { get; }

        public ITransmission<Space3D.Rotation> Rotation { get; }

        internal PoseTracker(IPoseTrackerConfiguration configuration)
        {
            Position = new PropagationWithoutCache<Space3D.Position>().Transmit(configuration.Position);

            Rotation = new PropagationWithoutCache<Space3D.Rotation>().Transmit(configuration.Rotation);
        }
    }
}
