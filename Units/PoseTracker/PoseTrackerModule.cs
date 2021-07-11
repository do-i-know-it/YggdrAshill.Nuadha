using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class PoseTrackerModule :
        IPoseTrackerHardwareHandler,
        IPoseTrackerSoftwareHandler,
        IModule<IPoseTrackerHardwareHandler, IPoseTrackerSoftwareHandler>
    {
        private readonly IPropagation<Space3D.Position> position;

        private readonly IPropagation<Space3D.Rotation> rotation;

        internal PoseTrackerModule(IPoseTrackerModule module)
        {
            position = module.Position;

            rotation = module.Rotation;
        }

        public IPoseTrackerHardwareHandler HardwareHandler => this;

        public IPoseTrackerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            position.Dispose();

            rotation.Dispose();
        }

        IConsumption<Space3D.Position> IPoseTrackerHardwareHandler.Position => position;

        IConsumption<Space3D.Rotation> IPoseTrackerHardwareHandler.Rotation => rotation;

        IProduction<Space3D.Position> IPoseTrackerSoftwareHandler.Position => position;

        IProduction<Space3D.Rotation> IPoseTrackerSoftwareHandler.Rotation => rotation;
    }
}
