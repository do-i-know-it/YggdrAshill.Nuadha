using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class WhenPush :
        IDetection<Push>
    {
        public static WhenPush IsDisabled { get; } = new WhenPush(Push.Disabled);

        public static WhenPush IsEnabled { get; } = new WhenPush(Push.Enabled);

        private readonly Push expected;

        private WhenPush(Push expected)
        {
            this.expected = expected;
        }

        /// <inheritdoc/>
        public bool Detect(Push signal)
        {
            return expected == signal;
        }
    }
}
