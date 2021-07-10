using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class IgniteStick :
        IIgnition<IStickHardwareHandler>
    {
        private readonly ITransmission<Touch> touch;

        private readonly ITransmission<Tilt> tilt;

        internal IgniteStick(IStick device)
        {
            touch = device.Touch;

            tilt = device.Tilt;
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
