using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ICondition{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public sealed class PulseIs :
        ICondition<Pulse>
    {
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasDisabled"/> or <see cref="Pulse.IsDisabled"/>.
        /// </summary>
        public static PulseIs Disabled { get; } = new PulseIs(Pulse.IsDisabled, Pulse.HasDisabled);

        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasEnabled"/> or <see cref="Pulse.IsEnabled"/>.
        /// </summary>
        public static PulseIs Enabled { get; } = new PulseIs(Pulse.IsEnabled, Pulse.HasEnabled);

        private readonly Pulse first;

        private readonly Pulse second;

        private PulseIs(Pulse first, Pulse second)
        {
            this.first = first;

            this.second = second;
        }

        /// <inheritdoc/>
        public bool IsSatisfiedBy(Pulse signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return signal == first || signal == second;
        }
    }
}
