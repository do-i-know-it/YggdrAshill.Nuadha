using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class HandController :
        IHandControllerSoftware,
        IHandControllerHardware,
        IProtocol<IHandControllerSoftware, IHandControllerHardware>
    {
        /// <summary>
        /// <see cref="HandController"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="HandController"/> without cache.
        /// </returns>
        public static HandController WithoutCache()
        {
            return new HandController(
                PoseTracker.WithoutCache(),
                Stick.WithoutCache(),
                Trigger.WithoutCache(),
                Trigger.WithoutCache());
        }

        /// <summary>
        /// <see cref="HandController"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="HandController"/> with latest cache.
        /// </returns>
        public static HandController WithLatestCache()
        {
            return new HandController(
                PoseTracker.WithLatestCache(),
                Stick.WithLatestCache(),
                Trigger.WithLatestCache(),
                Trigger.WithLatestCache());
        }

        internal PoseTracker Pose { get; }

        internal Stick Thumb { get; }

        internal Trigger IndexFinger { get; }

        internal Trigger HandGrip { get; }

        private HandController(PoseTracker pose, Stick thumb, Trigger indexFinger, Trigger handGrip)
        {
            Pose = pose;

            Thumb = thumb;

            IndexFinger = indexFinger;

            HandGrip = handGrip;
        }

        /// <inheritdoc/>
        public IHandControllerSoftware Hardware => this;

        /// <inheritdoc/>
        public IHandControllerHardware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Pose.Dispose();

            Thumb.Dispose();

            IndexFinger.Dispose();

            HandGrip.Dispose();
        }

        /// <inheritdoc/>
        IPoseTrackerSoftware IHandControllerSoftware.Pose => Pose.Hardware;

        /// <inheritdoc/>
        IStickSoftware IHandControllerSoftware.Thumb => Thumb.Hardware;

        /// <inheritdoc/>
        ITriggerSoftware IHandControllerSoftware.IndexFinger => IndexFinger.Hardware;

        /// <inheritdoc/>
        ITriggerSoftware IHandControllerSoftware.HandGrip => HandGrip.Hardware;

        /// <inheritdoc/>
        IPoseTrackerHardware IHandControllerHardware.Pose => Pose.Software;

        /// <inheritdoc/>
        IStickHardware IHandControllerHardware.Thumb => Thumb.Software;

        /// <inheritdoc/>
        ITriggerHardware IHandControllerHardware.IndexFinger => IndexFinger.Software;

        /// <inheritdoc/>
        ITriggerHardware IHandControllerHardware.HandGrip => HandGrip.Software;
    }
}
