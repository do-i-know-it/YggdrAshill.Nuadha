using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedTiltModule :
        IModule<IPulsatedTiltHardwareHandler, IPulsatedTiltSoftwareHandler>,
        IPulsatedTiltHardwareHandler,
        IPulsatedTiltSoftwareHandler,
        IDisposable
    {
        private IPropagation<Pulse> Distance { get; }

        private IPropagation<Pulse> Left { get; }

        private IPropagation<Pulse> Right { get; }

        private IPropagation<Pulse> Forward { get; }

        private IPropagation<Pulse> Backward { get; }

        public PulsatedTiltModule(
            IPropagation<Pulse> distance,
            IPropagation<Pulse> left,
            IPropagation<Pulse> right,
            IPropagation<Pulse> forward,
            IPropagation<Pulse> backward)
        {
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
            if (forward == null)
            {
                throw new ArgumentNullException(nameof(forward));
            }
            if (backward == null)
            {
                throw new ArgumentNullException(nameof(backward));
            }

            Distance = distance;

            Left = left;

            Right = right;

            Forward = forward;

            Backward = backward;
        }

        public IPulsatedTiltHardwareHandler HardwareHandler => this;

        public IPulsatedTiltSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Distance.Dispose();

            Left.Dispose();

            Right.Dispose();

            Forward.Dispose();

            Backward.Dispose();
        }

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Distance => Distance;

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Left => Left;

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Right => Right;

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Forward => Forward;

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Backward => Backward;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Distance => Distance;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Left => Left;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Right => Right;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Forward => Forward;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Backward => Backward;
    }
}
