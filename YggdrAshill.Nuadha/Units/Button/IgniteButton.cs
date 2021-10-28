using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteButton :
        IIgnition<IButtonSoftware>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Push> push;

        internal IgniteButton(Button protocol, IButtonConfiguration configuration)
        {
            touch = protocol.Touch.Transmit(configuration.Touch);

            push = protocol.Push.Transmit(configuration.Push);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IButtonSoftware module)
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
