using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
    /// </summary>
    public sealed class PushIs :
        INotification<Push>
    {
        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Disabled"/>.
        /// </summary>
        public static INotification<Push> Disabled { get; } = new PushIs(Push.Disabled);

        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Enabled"/>.
        /// </summary>
        public static INotification<Push> Enabled { get; } = new PushIs(Push.Enabled);

        private readonly Push expected;

        private PushIs(Push expected)
        {
            this.expected = expected;
        }

        public bool Notify(Push signal)
        {
            return expected == signal;
        }
    }
}
