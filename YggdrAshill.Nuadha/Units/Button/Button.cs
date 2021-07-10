using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Button :
       IIgnition<IButtonHardwareHandler>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Push> push;

        public Button(ITransmission<Touch> touch, ITransmission<Push> push)
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

            var synthesized = new SynthesizedCancellation();

            touch.Produce(handler.Touch).Synthesize(synthesized);
            push.Produce(handler.Push).Synthesize(synthesized);

            return synthesized;
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
