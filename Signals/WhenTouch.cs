using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class WhenTouch :
        IDetection<Touch>
    {
        public static WhenTouch IsDisabled { get; } = new WhenTouch(Touch.Disabled);

        public static WhenTouch IsEnabled { get; } = new WhenTouch(Touch.Enabled);

        private readonly Touch expected;

        private WhenTouch(Touch expected)
        {
            this.expected = expected;
        }

        /// <inheritdoc/>
        public bool Detect(Touch signal)
        {
            return expected == signal;
        }
    }
}
