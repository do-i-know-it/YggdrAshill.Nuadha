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
                Propagate<Battery>.WithLatestCache(Battery.Full),
                Propagate<Space3D.Pose>.WithLatestCache(Space3D.Pose.Origin),
                Propagate<Stick>.WithLatestCache(Stick.None),
                Propagate<Trigger>.WithLatestCache(Trigger.None),
                Propagate<Trigger>.WithLatestCache(Trigger.None));
        }

        private HandControllerModule(IPropagation<Battery> battery, IPropagation<Space3D.Pose> pose, IPropagation<Stick> thumb, IPropagation<Trigger> indexFinger, IPropagation<Trigger> handGrip)
        {
            this.battery = battery;

            this.pose = pose;

            this.thumb = thumb;

            this.indexFinger = indexFinger;

            this.handGrip = handGrip;
        }

        private readonly IPropagation<Battery> battery;

        private readonly IPropagation<Space3D.Pose> pose;

        private readonly IPropagation<Stick> thumb;

        private readonly IPropagation<Trigger> indexFinger;

        private readonly IPropagation<Trigger> handGrip;

        /// <inheritdoc/>
        public IHandControllerHardware Hardware => this;

        /// <inheritdoc/>
        public IHandControllerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Battery> IHandControllerHardware.Battery => battery;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHandControllerHardware.Pose => pose;

        /// <inheritdoc/>
        IProduction<Stick> IHandControllerHardware.Thumb => thumb;

        /// <inheritdoc/>
        IProduction<Trigger> IHandControllerHardware.IndexFinger => indexFinger;

        /// <inheritdoc/>
        IProduction<Trigger> IHandControllerHardware.HandGrip => handGrip;

        /// <inheritdoc/>
        IConsumption<Battery> IHandControllerSoftware.Battery => battery;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHandControllerSoftware.Pose => pose;

        /// <inheritdoc/>
        IConsumption<Stick> IHandControllerSoftware.Thumb => thumb;

        /// <inheritdoc/>
        IConsumption<Trigger> IHandControllerSoftware.IndexFinger => indexFinger;

        /// <inheritdoc/>
        IConsumption<Trigger> IHandControllerSoftware.HandGrip => handGrip;
    }
}
