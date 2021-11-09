using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    /// </summary>
    public sealed class HandController :
        IHandControllerHardware,
        IHandControllerSoftware,
        IProtocol<IHandControllerHardware, IHandControllerSoftware>
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
        public IHandControllerHardware Hardware => this;

        /// <inheritdoc/>
        public IHandControllerSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Pose.Dispose();

            Thumb.Dispose();

            IndexFinger.Dispose();

            HandGrip.Dispose();
        }

        IPoseTrackerHardware IHandControllerHardware.Pose => Pose.Hardware;

        IStickHardware IHandControllerHardware.Thumb => Thumb.Hardware;

        ITriggerHardware IHandControllerHardware.IndexFinger => IndexFinger.Hardware;

        ITriggerHardware IHandControllerHardware.HandGrip => HandGrip.Hardware;

        IPoseTrackerSoftware IHandControllerSoftware.Pose => Pose.Software;

        IStickSoftware IHandControllerSoftware.Thumb => Thumb.Software;

        ITriggerSoftware IHandControllerSoftware.IndexFinger => IndexFinger.Software;

        ITriggerSoftware IHandControllerSoftware.HandGrip => HandGrip.Software;
    }
}
