using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
    /// </summary>
    public static class TouchIs
    {
        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Disabled"/>.
        /// </summary>
        public static INotification<Touch> Disabled { get; } = new Notification(Touch.Disabled);

        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Enabled"/>.
        /// </summary>
        public static INotification<Touch> Enabled { get; } = new Notification(Touch.Enabled);

        private sealed class Notification :
           INotification<Touch>
        {
            private readonly Touch expected;

            internal Notification(Touch expected)
            {
                this.expected = expected;
            }

            public bool Notify(Touch signal)
            {
                return expected == signal;
            }
        }
    }
}
