using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IHandControllerProtocol"/>.
    /// </summary>
    public sealed class HandController :
        IHandControllerHardware,
        IHandControllerSoftware,
        IHandControllerProtocol
    {
        public static ITransmission<IHandControllerSoftware> Transmit(IHandControllerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Transmit(configuration);
        }

        /// <summary>
        /// <see cref="IHandControllerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHandControllerProtocol"/> initialized.
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
        /// <param name="configuration">
        /// <see cref="IHandControllerConfiguration"/> to initialize.
        /// </param>
        /// <returns>
        /// <see cref="IHandControllerProtocol"/> initialized.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IHandControllerProtocol WithLatestCache(IHandControllerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new HandController(
                PoseTracker.WithLatestCache(configuration.Pose),
                Stick.WithLatestCache(configuration.Thumb),
                Trigger.WithLatestCache(configuration.IndexFinger),
                Trigger.WithLatestCache(configuration.HandGrip));
        }

        /// <summary>
        /// <see cref="IHandControllerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHandControllerProtocol"/> initialized.
        /// </returns>
        public static IHandControllerProtocol WithLatestCache()
        {
            return WithLatestCache(Imitate.HandController);
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
