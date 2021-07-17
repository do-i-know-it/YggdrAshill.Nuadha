using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ICondition{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public sealed class PulseHas :
        ICondition<Pulse>
    {
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasDisabled"/>.
        /// </summary>
        public static PulseHas Disabled { get; } = new PulseHas(Pulse.HasDisabled);
        
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasEnabled"/>.
        /// </summary>
        public static PulseHas Enabled { get; } = new PulseHas(Pulse.HasEnabled);

        private readonly Pulse expected;

        private PulseHas(Pulse expected)
        {
            this.expected = expected;
        }

        /// <inheritdoc/>
        public bool IsSatisfiedBy(Pulse signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected == signal;
        }
    }
}
