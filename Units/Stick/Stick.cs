using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class Stick :
        IIgnition<IStickSoftware>
    {
        private readonly IConduction<Touch> touch;

        private readonly IConduction<Tilt> tilt;

        public Stick(IConduction<Touch> touch, IConduction<Tilt> tilt)
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

        public ICancellation Connect(IStickSoftware handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return touch.Produce(handler.Touch)
                .Synthesize(tilt.Produce(handler.Tilt));
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
