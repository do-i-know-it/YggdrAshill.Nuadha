using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Push"/>
    /// </summary>
    public static class PushIs
    {
        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Disabled"/>.
        /// </summary>
        public static INotification<Push> Disabled { get; } = new Notification(Push.Disabled);

        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Enabled"/>.
        /// </summary>
        public static INotification<Push> Enabled { get; } = new Notification(Push.Enabled);

        private sealed class Notification :
           INotification<Push>
        {
            private readonly Push expected;

            internal Notification(Push expected)
            {
                this.expected = expected;
            }

            public bool Notify(Push signal)
            {
                return expected == signal;
            }
        }
    }
}
