using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class HeadTrackerModule :
        IHeadTrackerHardwareHandler,
        IHeadTrackerSoftwareHandler,
        IModule<IHeadTrackerHardwareHandler, IHeadTrackerSoftwareHandler>
    {
        internal PoseTrackerModule Pose { get; }

        internal IPropagation<Space3D.Direction> Direction { get; }

        public HeadTrackerModule(PoseTrackerModule pose, IPropagation<Space3D.Direction> direction)
        {
            if (pose == null)
            {
                throw new ArgumentNullException(nameof(pose));
            }
            if (direction == null)
            {
                throw new ArgumentNullException(nameof(direction));
            }

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
