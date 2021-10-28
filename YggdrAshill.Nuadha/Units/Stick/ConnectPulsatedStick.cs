using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedStick :
        IConnection<IPulsatedStickSoftware>
    {
        private readonly IProduction<Pulse> touch;

        private readonly ConnectPulsatedTilt tilt;

        internal ConnectPulsatedStick(IStickHardware module, TiltThreshold threshold)
        {
            touch = module.Touch.Convert(TouchInto.Pulse);

            tilt = new ConnectPulsatedTilt(module.Tilt, threshold);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPulsatedStickSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            var composite = new CompositeCancellation();

            touch.Produce(module.Touch).Synthesize(composite);
            tilt.Connect(module.Tilt).Synthesize(composite);

            return composite;
        }
    }
}
