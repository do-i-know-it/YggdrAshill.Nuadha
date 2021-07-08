using YggdrAshill.Nuadha.Unitization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public sealed class HandControllerModule :
        IModule<IHandControllerHardware, IHandControllerSoftware>,
        IHandControllerHardware,
        IHandControllerSoftware
    {
        private readonly PoseTrackerModule pose;

        private readonly StickModule thumb;

        private readonly TriggerModule indexFinger;

        private readonly TriggerModule handGrip;

        public HandControllerModule(PoseTrackerModule pose, StickModule thumb, TriggerModule indexFinger, TriggerModule handGrip)
        {
            if (pose == null)
            {
                throw new ArgumentNullException(nameof(pose));
            }
            if (thumb == null)
            {
                throw new ArgumentNullException(nameof(thumb));
            }
            if (indexFinger == null)
            {
                throw new ArgumentNullException(nameof(indexFinger));
            }
            if (handGrip == null)
            {
                throw new ArgumentNullException(nameof(handGrip));
            }

            this.pose = pose;

            this.thumb = thumb;

            this.indexFinger = indexFinger;

            this.handGrip = handGrip;
        }

        #region IModule

        public IHandControllerHardware Hardware => this;

        public IHandControllerSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            pose.Dispose();

            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }

        #endregion

        #region IHandControllerHardware

        IPoseTrackerHardware IHandControllerHardware.Pose => pose;

        IStickHardware IHandControllerHardware.Thumb => thumb;

        ITriggerHardware IHandControllerHardware.IndexFinger => indexFinger;

        ITriggerHardware IHandControllerHardware.HandGrip => handGrip;

        #endregion

        #region IHandControllerSoftware

        IPoseTrackerSoftware IHandControllerSoftware.Pose => pose;

        IStickSoftware IHandControllerSoftware.Thumb => thumb;

        ITriggerSoftware IHandControllerSoftware.IndexFinger => indexFinger;

        ITriggerSoftware IHandControllerSoftware.HandGrip => handGrip;

        #endregion
    }
}
