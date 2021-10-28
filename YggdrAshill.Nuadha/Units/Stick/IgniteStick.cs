using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteStick :
        IIgnition<IStickSoftware>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Tilt> tilt;

        internal IgniteStick(Stick protocol, IStickConfiguration configuration)
        {
            touch = protocol.Touch.Transmit(configuration.Touch);

            tilt = protocol.Tilt.Transmit(configuration.Tilt);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IStickSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            var composite = new CompositeCancellation();

            touch.Produce(module.Touch).Synthesize(composite);
            tilt.Produce(module.Tilt).Synthesize(composite);

            return composite;
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
