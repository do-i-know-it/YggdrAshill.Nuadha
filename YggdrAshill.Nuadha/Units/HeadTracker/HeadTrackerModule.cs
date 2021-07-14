using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadTrackerModule :
        IHeadTrackerHardwareHandler,
        IHeadTrackerSoftwareHandler,
        IModule<IHeadTrackerHardwareHandler, IHeadTrackerSoftwareHandler>
    {
        public static HeadTrackerModule WithoutCache()
        {
            return new HeadTrackerModule(PoseTrackerModule.WithoutCache(), Propagation.WithoutCache.Create<Space3D.Direction>());
        }

        internal PoseTrackerModule Pose { get; }

        internal IPropagation<Space3D.Direction> Direction { get; }

        private HeadTrackerModule(PoseTrackerModule pose, IPropagation<Space3D.Direction> direction)
        {
            Pose = pose;

            Direction = direction;
        }

        public IHeadTrackerHardwareHandler HardwareHandler => this;

        public IHeadTrackerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Pose.Dispose();

            Direction.Dispose();
        }

        IPoseTrackerHardwareHandler IHeadTrackerHardwareHandler.Pose => Pose.HardwareHandler;

        IConsumption<Space3D.Direction> IHeadTrackerHardwareHandler.Direction => Direction;

        IPoseTrackerSoftwareHandler IHeadTrackerSoftwareHandler.Pose => Pose.SoftwareHandler;

        IProduction<Space3D.Direction> IHeadTrackerSoftwareHandler.Direction => Direction;
    }
}
