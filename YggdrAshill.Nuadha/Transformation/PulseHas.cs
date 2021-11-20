using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ICondition{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class PulseHas
    {
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasDisabled"/>.
        /// </summary>
        public static ICondition<Pulse> Disabled { get; } = new Condition(Pulse.HasDisabled);
        
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasEnabled"/>.
        /// </summary>
        public static ICondition<Pulse> Enabled { get; } = new Condition(Pulse.HasEnabled);

        private sealed class Condition :
           ICondition<Pulse>
        {
            private readonly Pulse expected;

            internal Condition(Pulse expected)
            {
                this.expected = expected;
            }

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
}
