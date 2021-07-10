using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class PulsatedStick :
        IConnection<IPulsatedStickHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly PulsatedTilt tilt;

        internal PulsatedStick(IStickSoftwareHandler handler, TiltThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            touch = handler.Touch.Convert(TouchInto.Pulse);

            tilt = new PulsatedTilt(handler.Tilt, threshold);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPulsatedStickHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            touch.Produce(handler.Touch).Synthesize(synthesized);
            tilt.Connect(handler.Tilt).Synthesize(synthesized);

            return synthesized;
        }
    }
}
