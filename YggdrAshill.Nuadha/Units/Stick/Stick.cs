using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Stick :
        IIgnition<IStickHardwareHandler>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Tilt> tilt;

        public Stick(ITransmission<Touch> touch, ITransmission<Tilt> tilt)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (tilt == null)
            {
                throw new ArgumentNullException(nameof(tilt));
            }

            this.touch = touch;

            this.tilt = tilt;
        }

        public ICancellation Connect(IStickHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            touch.Produce(handler.Touch).Synthesize(synthesized);
            tilt.Produce(handler.Tilt).Synthesize(synthesized);

            return synthesized;
        }

        public void Emit()
        {
            touch.Emit();

            tilt.Emit();
        }

        public void Dispose()
        {
            touch.Dispose();

            tilt.Dispose();
        }
    }
}
