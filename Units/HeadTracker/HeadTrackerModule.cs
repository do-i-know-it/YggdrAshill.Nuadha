using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class HeadTrackerModule :
        IModule<IHeadTrackerHardware, IHeadTrackerSoftware>,
        IHeadTrackerHardware,
        IHeadTrackerSoftware
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

        #region IModule

        public IHeadTrackerHardware Hardware => this;

        public IHeadTrackerSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            pose.Dispose();

            direction.Dispose();
        }

        #endregion

        #region IHeadsetHardware

        IPoseTrackerHardware IHeadTrackerHardware.Pose => pose;

        IProduction<Space3D.Direction> IHeadTrackerHardware.Direction => direction;

        #endregion

        #region IHeadsetSoftware

        IPoseTrackerSoftware IHeadTrackerSoftware.Pose => pose;

        IConsumption<Space3D.Direction> IHeadTrackerSoftware.Direction => direction;

        #endregion
    }
}
