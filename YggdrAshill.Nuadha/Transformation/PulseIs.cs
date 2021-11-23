using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class PulseIs
    {
        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasDisabled"/> or <see cref="Pulse.IsDisabled"/>.
        /// </summary>
        public static INotification<Pulse> Disabled { get; } = new Notification(Pulse.IsDisabled, Pulse.HasDisabled);

        /// <summary>
        /// When <see cref="Pulse"/> is <see cref="Pulse.HasEnabled"/> or <see cref="Pulse.IsEnabled"/>.
        /// </summary>
        public static INotification<Pulse> Enabled { get; } = new Notification(Pulse.IsEnabled, Pulse.HasEnabled);
        
        private sealed class Notification :
            INotification<Pulse>
        {
            private readonly Pulse first;

            private readonly Pulse second;

            internal Notification(Pulse first, Pulse second)
            {
                this.first = first;

                this.second = second;
            }

            public bool Notify(Pulse signal)
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
