using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedButton :
        IConnection<IPulsatedButtonHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> push;

        internal ConnectPulsatedButton(IButtonSoftwareHandler handler)
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

            var composite = new CompositeCancellation();

            touch.Produce(handler.Touch).Synthesize(composite);
            push.Produce(handler.Push).Synthesize(composite);

            return composite;
        }
    }
}
