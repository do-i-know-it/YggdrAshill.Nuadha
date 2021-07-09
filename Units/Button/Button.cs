using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class Button :
       IIgnition<IButtonHardwareHandler>
    {
        private readonly IConduction<Touch> touch;

        private readonly IConduction<Push> push;

        public Button(IConduction<Touch> touch, IConduction<Push> push)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (push == null)
            {
                throw new ArgumentNullException(nameof(push));
            }

            this.touch = touch;

            this.push = push;
        }

        public ICancellation Connect(IButtonHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return touch.Produce(handler.Touch)
                .Synthesize(push.Produce(handler.Push));
        }

        public void Emit()
        {
            touch.Emit();

            push.Emit();
        }

        public void Dispose()
        {
            touch.Dispose();

            push.Dispose();
        }
    }
}
