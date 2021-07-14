using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
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

            var synthesized = new SynthesizedCancellation();

            touch.Produce(handler.Touch).Synthesize(synthesized);
            push.Produce(handler.Push).Synthesize(synthesized);

            return synthesized;
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
