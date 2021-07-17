using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedStick :
        IConnection<IPulsatedStickHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly ConnectPulsatedTilt tilt;

        internal ConnectPulsatedStick(IStickSoftwareHandler handler, TiltThreshold threshold)
        {
            touch = handler.Touch.Convert(TouchInto.Pulse);

            tilt = new ConnectPulsatedTilt(handler.Tilt, threshold);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPulsatedStickHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var composite = new CompositeCancellation();

            touch.Produce(handler.Touch).Synthesize(composite);
            tilt.Connect(handler.Tilt).Synthesize(composite);

            return composite;
        }
    }
}
