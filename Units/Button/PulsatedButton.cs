using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
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

            touch = handler.Touch.Convert(new TouchToPulse());

            push = handler.Push.Convert(new PushToPulse());
        }

        public ICancellation Connect(IPulsatedButtonHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return touch.Produce(handler.Touch)
                .Synthesize(push.Produce(handler.Push));
        }
    }
}
