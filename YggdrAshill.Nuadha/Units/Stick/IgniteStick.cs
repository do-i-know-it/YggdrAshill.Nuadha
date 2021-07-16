using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteStick :
        IIgnition<IStickHardwareHandler>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Tilt> tilt;

        internal IgniteStick(StickModule module, IStickConfiguration configuration)
        {
            touch = module.Touch.Transmit(configuration.Touch);

            tilt = module.Tilt.Transmit(configuration.Tilt);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IStickHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            touch.Produce(handler.Touch).Synthesize(synthesized);
            tilt.Produce(handler.Tilt).Synthesize(synthesized);

            return synthesized;
        }

        /// <inheritdoc/>
        public void Emit()
        {
            touch.Emit();

            tilt.Emit();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            tilt.Dispose();
        }
    }
}
