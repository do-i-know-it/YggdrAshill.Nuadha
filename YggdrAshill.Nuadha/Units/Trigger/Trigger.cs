using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Trigger :
        IIgnition<ITriggerHardwareHandler>
    {
        private readonly IConduction<Touch> touch;

        private readonly IConduction<Pull> pull;

        public Trigger(IConduction<Touch> touch, IConduction<Pull> pull)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (pull == null)
            {
                throw new ArgumentNullException(nameof(pull));
            }

            this.touch = touch;

            this.pull = pull;
        }

        public ICancellation Connect(ITriggerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            touch.Produce(handler.Touch).Synthesize(synthesized);
            pull.Produce(handler.Pull).Synthesize(synthesized);

            return synthesized;
        }

        public void Emit()
        {
            touch.Emit();

            pull.Emit();
        }

        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }
    }
}
