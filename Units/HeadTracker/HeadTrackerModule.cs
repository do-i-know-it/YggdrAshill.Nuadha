using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class HeadTrackerModule :
        IHeadTrackerHardwareHandler,
        IHeadTrackerSoftwareHandler,
        IModule<IHeadTrackerHardwareHandler, IHeadTrackerSoftwareHandler>
    {
        private readonly PoseTrackerModule pose;

        private readonly IPropagation<Space3D.Direction> direction;

        internal HeadTrackerModule(IHeadTrackerModule module)
        {
            pose = new PoseTrackerModule(module.Pose);

            direction = module.Direction;
        }

        public IHeadTrackerHardwareHandler HardwareHandler => this;

        public IHeadTrackerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            pose.Dispose();

            direction.Dispose();
        }

        IPoseTrackerHardwareHandler IHeadTrackerHardwareHandler.Pose => pose.HardwareHandler;

        IConsumption<Space3D.Direction> IHeadTrackerHardwareHandler.Direction => direction;

        IPoseTrackerSoftwareHandler IHeadTrackerSoftwareHandler.Pose => pose.SoftwareHandler;

        IProduction<Space3D.Direction> IHeadTrackerSoftwareHandler.Direction => direction;
    }
}
