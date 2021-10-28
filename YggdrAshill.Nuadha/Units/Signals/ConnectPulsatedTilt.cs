using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedTilt :
        IConnection<IPulsatedTiltSoftware>
    {
        private readonly IProduction<Pulse> distance;

        private readonly IProduction<Pulse> left;

        private readonly IProduction<Pulse> right;

        private readonly IProduction<Pulse> forward;

        private readonly IProduction<Pulse> backward;

        internal ConnectPulsatedTilt(IProduction<Tilt> production, TiltThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            distance = production.Convert(TiltInto.PulseBy.Distance(threshold.Distance));
            left = production.Convert(TiltInto.PulseBy.Left(threshold.Left));
            right = production.Convert(TiltInto.PulseBy.Right(threshold.Right));
            forward = production.Convert(TiltInto.PulseBy.Forward(threshold.Forward));
            backward = production.Convert(TiltInto.PulseBy.Backward(threshold.Backward));
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPulsatedTiltSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            var composite = new CompositeCancellation();

            distance.Produce(module.Distance).Synthesize(composite);
            left.Produce(module.Left).Synthesize(composite);
            right.Produce(module.Right).Synthesize(composite);
            forward.Produce(module.Forward).Synthesize(composite);
            backward.Produce(module.Backward).Synthesize(composite);

            return composite;
        }
    }
}
