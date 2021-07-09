using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class StickPulsationModule :
        IModule<IStickPulsationHardware, IStickPulsationSoftware>,
        IStickPulsationHardware,
        IStickPulsationSoftware
    {
        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> distance;

        private readonly IPropagation<Pulse> left;

        private readonly IPropagation<Pulse> right;

        private readonly IPropagation<Pulse> upward;

        private readonly IPropagation<Pulse> downward;

        public StickPulsationModule(
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

        #region IModule

        public IStickPulsationHardware Hardware => this;

        public IStickPulsationSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            touch.Dispose();

            distance.Dispose();

            left.Dispose();

            right.Dispose();

            upward.Dispose();

            downward.Dispose();
        }

        #endregion

        #region IStickPulsationHardware

        IProduction<Pulse> IStickPulsationHardware.Touch => touch;

        IProduction<Pulse> IStickPulsationHardware.Distance => distance;

        IProduction<Pulse> IStickPulsationHardware.Left => left;

        IProduction<Pulse> IStickPulsationHardware.Right => right;

        IProduction<Pulse> IStickPulsationHardware.Forward => upward;

        IProduction<Pulse> IStickPulsationHardware.Backward => downward;

        #endregion

        #region IStickPulsationSoftware

        IConsumption<Pulse> IStickPulsationSoftware.Touch => touch;

        IConsumption<Pulse> IStickPulsationSoftware.Distance => distance;

        IConsumption<Pulse> IStickPulsationSoftware.Left => left;

        IConsumption<Pulse> IStickPulsationSoftware.Right => right;

        IConsumption<Pulse> IStickPulsationSoftware.Forward => upward;

        IConsumption<Pulse> IStickPulsationSoftware.Backward => downward;

        #endregion
    }
}
