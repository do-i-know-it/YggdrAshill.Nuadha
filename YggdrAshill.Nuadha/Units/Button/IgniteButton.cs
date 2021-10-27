using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteButton :
        IIgnition<IButtonHardwareHandler>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Push> push;

        internal IgniteButton(ButtonModule module, IButtonConfiguration configuration)
        {
            touch = module.Touch.Transmit(configuration.Touch);

            push = module.Push.Transmit(configuration.Push);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IButtonHardwareHandler handler)
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

        /// <inheritdoc/>
        public void Emit()
        {
            touch.Emit();

            push.Emit();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            push.Dispose();
        }
    }
}
