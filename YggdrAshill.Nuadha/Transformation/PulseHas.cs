using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class PulseHas
    {
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasDisabled"/>.
        /// </summary>
        public static INotification<Pulse> Disabled { get; } = new Notification(Pulse.HasDisabled);
        
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasEnabled"/>.
        /// </summary>
        public static INotification<Pulse> Enabled { get; } = new Notification(Pulse.HasEnabled);

        private sealed class Notification :
           INotification<Pulse>
        {
            private readonly Pulse expected;

            internal Notification(Pulse expected)
            {
                this.expected = expected;
            }

            public bool Notify(Pulse signal)
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
