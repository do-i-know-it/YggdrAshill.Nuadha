using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PulsatedStickModule :
        IModule<IPulsatedStickHardwareHandler, IPulsatedStickSoftwareHandler>,
        IPulsatedStickSoftwareHandler,
        IPulsatedStickHardwareHandler
    {
        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> distance;

        private readonly IPropagation<Pulse> left;

        private readonly IPropagation<Pulse> right;

        private readonly IPropagation<Pulse> upward;

        private readonly IPropagation<Pulse> downward;

        public PulsatedStickModule(
            IPropagation<Pulse> touch,
            IPropagation<Pulse> distance,
            IPropagation<Pulse> left,
            IPropagation<Pulse> right,
            IPropagation<Pulse> upward,
            IPropagation<Pulse> downward)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (distance == null)
            {
                throw new ArgumentNullException(nameof(distance));
            }
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            if (upward == null)
            {
                throw new ArgumentNullException(nameof(upward));
            }
            if (downward == null)
            {
                throw new ArgumentNullException(nameof(downward));
            }

            this.touch = touch;
            this.distance = distance;
            this.left = left;
            this.right = right;
            this.upward = upward;
            this.downward = downward;
        }

        public IPulsatedStickHardwareHandler HardwareHandler => this;

        public IPulsatedStickSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            touch.Dispose();

            distance.Dispose();

            left.Dispose();

            right.Dispose();

            upward.Dispose();

            downward.Dispose();
        }

        IConsumption<Pulse> IPulsatedStickHardwareHandler.Touch => touch;

        IConsumption<Pulse> IPulsatedStickHardwareHandler.Distance => distance;

        IConsumption<Pulse> IPulsatedStickHardwareHandler.Left => left;

        IConsumption<Pulse> IPulsatedStickHardwareHandler.Right => right;

        IConsumption<Pulse> IPulsatedStickHardwareHandler.Forward => upward;

        IConsumption<Pulse> IPulsatedStickHardwareHandler.Backward => downward;

        IProduction<Pulse> IPulsatedStickSoftwareHandler.Touch => touch;

        IProduction<Pulse> IPulsatedStickSoftwareHandler.Distance => distance;

        IProduction<Pulse> IPulsatedStickSoftwareHandler.Left => left;

        IProduction<Pulse> IPulsatedStickSoftwareHandler.Right => right;

        IProduction<Pulse> IPulsatedStickSoftwareHandler.Forward => upward;

        IProduction<Pulse> IPulsatedStickSoftwareHandler.Backward => downward;
    }
}
