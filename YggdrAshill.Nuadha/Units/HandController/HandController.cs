using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IHandControllerProtocol"/>.
    /// </summary>
    public sealed class HandController :
        IHandControllerHardware,
        IHandControllerSoftware,
        IHandControllerProtocol
    {
        /// <summary>
        /// Creates <see cref="IIgnition{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IHandControllerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IHandControllerSoftware> Ignite(IHandControllerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Ignite(configuration);
        }

        /// <summary>
        /// <see cref="IHandControllerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHandControllerProtocol"/> without cache.
        /// </returns>
        public static IHandControllerProtocol WithoutCache()
        {
            return new HandController(
                PoseTracker.WithoutCache(),
                Stick.WithoutCache(),
                Trigger.WithoutCache(),
                Trigger.WithoutCache());
        }

        /// <summary>
        /// <see cref="IHandControllerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHandControllerProtocol"/> with latest cache.
        /// </returns>
        public static IHandControllerProtocol WithLatestCache()
        {
            return new HandController(
                PoseTracker.WithLatestCache(),
                Stick.WithLatestCache(),
                Trigger.WithLatestCache(),
                Trigger.WithLatestCache());
        }

        /// <inheritdoc/>
        public IPoseTrackerProtocol Pose { get; }

        /// <inheritdoc/>
        public IStickProtocol Thumb { get; }

        /// <inheritdoc/>
        public ITriggerProtocol IndexFinger { get; }

        /// <inheritdoc/>
        public ITriggerProtocol HandGrip { get; }

        private HandController(IPoseTrackerProtocol pose, IStickProtocol thumb, ITriggerProtocol indexFinger, ITriggerProtocol handGrip)
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

        /// <inheritdoc/>
        IPoseTrackerHardware IHandControllerHardware.Pose => Pose.Hardware;

        /// <inheritdoc/>
        IStickHardware IHandControllerHardware.Thumb => Thumb.Hardware;

        /// <inheritdoc/>
        ITriggerHardware IHandControllerHardware.IndexFinger => IndexFinger.Hardware;

        /// <inheritdoc/>
        ITriggerHardware IHandControllerHardware.HandGrip => HandGrip.Hardware;

        /// <inheritdoc/>
        IPoseTrackerSoftware IHandControllerSoftware.Pose => Pose.Software;

        /// <inheritdoc/>
        IStickSoftware IHandControllerSoftware.Thumb => Thumb.Software;

        /// <inheritdoc/>
        ITriggerSoftware IHandControllerSoftware.IndexFinger => IndexFinger.Software;

        /// <inheritdoc/>
        ITriggerSoftware IHandControllerSoftware.HandGrip => HandGrip.Software;
    }
}
