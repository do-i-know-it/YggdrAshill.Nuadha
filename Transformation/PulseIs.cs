using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="ICondition{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class PulseIs
    {
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasDisabled"/> or <see cref="Pulse.IsDisabled"/>.
        /// </summary>
        public static ICondition<Pulse> Disabled { get; } = new Condition(Pulse.IsDisabled, Pulse.HasDisabled);

        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasEnabled"/> or <see cref="Pulse.IsEnabled"/>.
        /// </summary>
        public static ICondition<Pulse> Enabled { get; } = new Condition(Pulse.IsEnabled, Pulse.HasEnabled);
        
        private sealed class Condition :
            ICondition<Pulse>
        {
            private readonly Pulse first;

            private readonly Pulse second;

            internal Condition(Pulse first, Pulse second)
            {
                this.first = first;

                this.second = second;
            }

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
}
