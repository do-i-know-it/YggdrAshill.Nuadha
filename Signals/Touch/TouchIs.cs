using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
    /// </summary>
    public sealed class TouchIs :
        INotification<Touch>
    {
        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Disabled"/>.
        /// </summary>
        public static INotification<Touch> Disabled { get; } = new TouchIs(Touch.Disabled);

        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Enabled"/>.
        /// </summary>
        public static INotification<Touch> Enabled { get; } = new TouchIs(Touch.Enabled);

        private readonly Touch expected;

        private TouchIs(Touch expected)
        {
            this.expected = expected;
        }

        public bool Notify(Touch signal)
        {
            return expected == signal;
        }
    }
}
