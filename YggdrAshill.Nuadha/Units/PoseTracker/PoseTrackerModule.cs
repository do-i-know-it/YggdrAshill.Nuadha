using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerModule :
        IPoseTrackerHardwareHandler,
        IPoseTrackerSoftwareHandler,
        IModule<IPoseTrackerHardwareHandler, IPoseTrackerSoftwareHandler>
    {
        public static PoseTrackerModule WithoutCache()
        {
            return new PoseTrackerModule(
                Propagation.WithoutCache.Create<Space3D.Position>(),
                Propagation.WithoutCache.Create<Space3D.Rotation>());
        }

        public static PoseTrackerModule WithLatestCache()
        {
            return new PoseTrackerModule(
                Propagation.WithLatestCache.Create(Initialize.Space3D.Position),
                Propagation.WithLatestCache.Create(Initialize.Space3D.Rotation));
        }

        internal IPropagation<Space3D.Position> Position { get; }

        internal IPropagation<Space3D.Rotation> Rotation { get; }

        private PoseTrackerModule(IPropagation<Space3D.Position> position, IPropagation<Space3D.Rotation> rotation)
        {
            Position = position;

            Rotation = rotation;
        }

        public IPoseTrackerHardwareHandler HardwareHandler => this;

        public IPoseTrackerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Position.Dispose();

            Rotation.Dispose();
        }

        IConsumption<Space3D.Position> IPoseTrackerHardwareHandler.Position => Position;

        IConsumption<Space3D.Rotation> IPoseTrackerHardwareHandler.Rotation => Rotation;

        IProduction<Space3D.Position> IPoseTrackerSoftwareHandler.Position => Position;

        IProduction<Space3D.Rotation> IPoseTrackerSoftwareHandler.Rotation => Rotation;
    }
}
