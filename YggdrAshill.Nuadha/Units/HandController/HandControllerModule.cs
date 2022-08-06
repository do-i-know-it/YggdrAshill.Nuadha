using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IHandControllerModule"/>.
    /// </summary>
    public sealed class HandControllerModule :
        IHandControllerHardware,
        IHandControllerSoftware,
        IHandControllerModule
    {
        /// <summary>
        /// <see cref="IHandControllerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHandControllerModule"/> initialized.
        /// </returns>
        public static IHandControllerModule WithoutCache()
        {
            return new HandControllerModule(
                Propagate<Battery>.WithoutCache(),
                Propagate<Space3D.Pose>.WithoutCache(),
                Propagate<Stick>.WithoutCache(),
                Propagate<Trigger>.WithoutCache(),
                Propagate<Trigger>.WithoutCache());
        }

        /// <summary>
        /// <see cref="IHandControllerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHandControllerModule"/> initialized.
        /// </returns>
        public static IHandControllerModule WithLatestCache()
        {
            return new HandControllerModule(
                Propagate<Battery>.WithLatestCache(Signals.Battery.Full),
                Propagate<Space3D.Pose>.WithLatestCache(Space3D.Pose.Origin),
                Propagate<Stick>.WithLatestCache(Stick.None),
                Propagate<Trigger>.WithLatestCache(Trigger.None),
                Propagate<Trigger>.WithLatestCache(Trigger.None));
        }

        private HandControllerModule(IPropagation<Battery> battery, IPropagation<Space3D.Pose> pose, IPropagation<Stick> thumb, IPropagation<Trigger> indexFinger, IPropagation<Trigger> handGrip)
        {
            Battery = battery;

            Pose = pose;

            Thumb = thumb;

            IndexFinger = indexFinger;

            HandGrip = handGrip;
        }

        /// <inheritdoc/>
        public IPropagation<Battery> Battery { get; }

        /// <inheritdoc/>
        public IPropagation<Space3D.Pose> Pose { get; }

        /// <inheritdoc/>
        public IPropagation<Stick> Thumb { get; }

        /// <inheritdoc/>
        public IPropagation<Trigger> IndexFinger { get; }

        /// <inheritdoc/>
        public IPropagation<Trigger> HandGrip { get; }

        /// <inheritdoc/>
        public IHandControllerHardware Hardware => this;

        /// <inheritdoc/>
        public IHandControllerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Battery> IHandControllerHardware.Battery => Battery;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHandControllerHardware.Pose => Pose;

        /// <inheritdoc/>
        IProduction<Stick> IHandControllerHardware.Thumb => Thumb;

        /// <inheritdoc/>
        IProduction<Trigger> IHandControllerHardware.IndexFinger => IndexFinger;

        /// <inheritdoc/>
        IProduction<Trigger> IHandControllerHardware.HandGrip => HandGrip;

        /// <inheritdoc/>
        IConsumption<Battery> IHandControllerSoftware.Battery => Battery;

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
