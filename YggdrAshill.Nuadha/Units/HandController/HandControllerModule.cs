using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class HandControllerModule :
        IHandControllerHardwareHandler,
        IHandControllerSoftwareHandler,
        IModule<IHandControllerHardwareHandler, IHandControllerSoftwareHandler>
    {
        /// <summary>
        /// <see cref="HandControllerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="HandControllerModule"/> without cache.
        /// </returns>
        public static HandControllerModule WithoutCache()
        {
            return new HandControllerModule(
                PoseTrackerModule.WithoutCache(),
                StickModule.WithoutCache(),
                TriggerModule.WithoutCache(),
                TriggerModule.WithoutCache());
        }

        /// <summary>
        /// <see cref="HandControllerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="HandControllerModule"/> with latest cache.
        /// </returns>
        public static HandControllerModule WithLatestCache()
        {
            return new HandControllerModule(
                PoseTrackerModule.WithLatestCache(),
                StickModule.WithLatestCache(),
                TriggerModule.WithLatestCache(),
                TriggerModule.WithLatestCache());
        }

        internal PoseTrackerModule Pose { get; }

        internal StickModule Thumb { get; }

        internal TriggerModule IndexFinger { get; }

        internal TriggerModule HandGrip { get; }

        private HandControllerModule(PoseTrackerModule pose, StickModule thumb, TriggerModule indexFinger, TriggerModule handGrip)
        {
            Pose = pose;

            Thumb = thumb;

            IndexFinger = indexFinger;

            HandGrip = handGrip;
        }

        /// <inheritdoc/>
        public IHandControllerHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IHandControllerSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Pose.Dispose();

            Thumb.Dispose();

            IndexFinger.Dispose();

            HandGrip.Dispose();
        }

        /// <inheritdoc/>
        IPoseTrackerHardwareHandler IHandControllerHardwareHandler.Pose => Pose.HardwareHandler;

        /// <inheritdoc/>
        IStickHardwareHandler IHandControllerHardwareHandler.Thumb => Thumb.HardwareHandler;

        /// <inheritdoc/>
        ITriggerHardwareHandler IHandControllerHardwareHandler.IndexFinger => IndexFinger.HardwareHandler;

        /// <inheritdoc/>
        ITriggerHardwareHandler IHandControllerHardwareHandler.HandGrip => HandGrip.HardwareHandler;

        /// <inheritdoc/>
        IPoseTrackerSoftwareHandler IHandControllerSoftwareHandler.Pose => Pose.SoftwareHandler;

        /// <inheritdoc/>
        IStickSoftwareHandler IHandControllerSoftwareHandler.Thumb => Thumb.SoftwareHandler;

        /// <inheritdoc/>
        ITriggerSoftwareHandler IHandControllerSoftwareHandler.IndexFinger => IndexFinger.SoftwareHandler;

        /// <inheritdoc/>
        ITriggerSoftwareHandler IHandControllerSoftwareHandler.HandGrip => HandGrip.SoftwareHandler;
    }
}
