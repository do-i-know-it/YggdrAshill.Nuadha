using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    public sealed class HandController :
        IHandControllerHardware,
        IHandControllerSoftware,
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

        IPoseTrackerHardware IHandControllerHardware.Pose => Pose.Software;

        IStickHardware IHandControllerHardware.Thumb => Thumb.Software;

        ITriggerHardware IHandControllerHardware.IndexFinger => IndexFinger.Software;

        ITriggerHardware IHandControllerHardware.HandGrip => HandGrip.Software;

        IPoseTrackerSoftware IHandControllerSoftware.Pose => Pose.Hardware;

        IStickSoftware IHandControllerSoftware.Thumb => Thumb.Hardware;

        ITriggerSoftware IHandControllerSoftware.IndexFinger => IndexFinger.Hardware;

        ITriggerSoftware IHandControllerSoftware.HandGrip => HandGrip.Hardware;
    }
}
