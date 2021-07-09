using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class PulsatedButton :
        IConnection<IPulsatedButtonHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> push;

        internal PulsatedButton(IButtonSoftwareHandler handler)
        {
            touch = handler.Touch.Convert(TouchInto.Pulse);

            push = handler.Push.Convert(PushInto.Pulse);
        }

        /// <inheritdoc/>
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
