using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadTrackerModule :
        IModule<IHeadTrackerHardwareHandler, IHeadTrackerSoftwareHandler>,
        IHeadTrackerHardwareHandler,
        IHeadTrackerSoftwareHandler
    {
        private readonly PoseTrackerModule pose;

        private readonly IPropagation<Space3D.Direction> direction;

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

            this.pose = pose;

            this.direction = direction;
        }

        public IHeadTrackerHardwareHandler HardwareHandler => this;

        public IHeadTrackerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            pose.Dispose();

            direction.Dispose();
        }

        IPoseTrackerHardwareHandler IHeadTrackerHardwareHandler.Pose => pose;

        IConsumption<Space3D.Direction> IHeadTrackerHardwareHandler.Direction => direction;

        IPoseTrackerSoftwareHandler IHeadTrackerSoftwareHandler.Pose => pose;

        IProduction<Space3D.Direction> IHeadTrackerSoftwareHandler.Direction => direction;
    }
}