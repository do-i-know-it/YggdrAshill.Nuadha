using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedButton :
        IConnection<IPulsatedButtonSoftware>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> push;

        internal ConnectPulsatedButton(IButtonHardware module)
        {
            touch = module.Touch.Convert(TouchInto.Pulse);

            push = module.Push.Convert(PushInto.Pulse);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPulsatedButtonSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            var composite = new CompositeCancellation();

            touch.Produce(module.Touch).Synthesize(composite);
            push.Produce(module.Push).Synthesize(composite);

            return composite;
        }
    }
}
