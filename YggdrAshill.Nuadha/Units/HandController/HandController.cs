using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
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
        /// <summary>
        /// Converts <see cref="IHandControllerConfiguration"/> into <see cref="ITransmission{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IHandControllerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IHandControllerSoftware"/> converted from <see cref="IHandControllerConfiguration"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
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
                Propagate.WithoutCache<Space3D.Pose>(),
                Propagate.WithoutCache<Stick>(),
                Propagate.WithoutCache<Trigger>(),
                Propagate.WithoutCache<Trigger>());
        }

        /// <summary>
        /// <see cref="IHandControllerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHandControllerProtocol"/> initialized.
        /// </returns>
        public static IHandControllerProtocol WithLatestCache()
        {
            return new HandController(
                Propagate.WithLatestCache(Imitate.Pose),
                Propagate.WithLatestCache(Imitate.Stick),
                Propagate.WithLatestCache(Imitate.Trigger),
                Propagate.WithLatestCache(Imitate.Trigger));
        }

        /// <inheritdoc/>
        public IPropagation<Space3D.Pose> Pose { get; }

        /// <inheritdoc/>
        public IPropagation<Stick> Thumb { get; }

        /// <inheritdoc/>
        public IPropagation<Trigger> IndexFinger { get; }

        /// <inheritdoc/>
        public IPropagation<Trigger> HandGrip { get; }

        private HandController(IPropagation<Space3D.Pose> pose, IPropagation<Stick> thumb, IPropagation<Trigger> indexFinger, IPropagation<Trigger> handGrip)
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
        IProduction<Space3D.Pose> IHandControllerHardware.Pose => Pose;

        /// <inheritdoc/>
        IProduction<Stick> IHandControllerHardware.Thumb => Thumb;

        /// <inheritdoc/>
        IProduction<Trigger> IHandControllerHardware.IndexFinger => IndexFinger;

        /// <inheritdoc/>
        IProduction<Trigger> IHandControllerHardware.HandGrip => HandGrip;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHandControllerSoftware.Pose => Pose;

        /// <inheritdoc/>
        IConsumption<Stick> IHandControllerSoftware.Thumb => Thumb;

        /// <inheritdoc/>
        IConsumption<Trigger> IHandControllerSoftware.IndexFinger => IndexFinger;

        /// <inheritdoc/>
        IConsumption<Trigger> IHandControllerSoftware.HandGrip => HandGrip;
    }
}
