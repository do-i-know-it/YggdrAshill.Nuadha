using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedButton :
        IConnection<IPulsatedButtonHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> push;

        public PulsatedButton(IButtonSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            touch = handler.Touch.Convert();

            push = handler.Push.Convert();
        }

        public ICancellation Connect(IPulsatedButtonHardwareHandler handler)
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
    }
}
