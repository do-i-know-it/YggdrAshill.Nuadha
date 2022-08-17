using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
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
        public static IHandControllerModule WithList()
        {
            return new HandControllerModule(
                Propagate<Battery>.WithList(),
                Propagate<Space3D.Pose>.WithList(),
                Propagate<Stick>.WithList(),
                Propagate<Trigger>.WithList(),
                Propagate<Trigger>.WithList());
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
        public void Dispose()
        {
            battery.Dispose();

            pose.Dispose();

            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }

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
