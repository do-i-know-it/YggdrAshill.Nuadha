using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    public static class WhenSignalOf
    {
        public sealed class TouchIs :
            IDetection<Touch>
        {
            public static TouchIs Disabled { get; } = new TouchIs(Touch.Disabled);
            
            public static TouchIs Enabled { get; } = new TouchIs(Touch.Enabled);

            private readonly Touch expected;

            private TouchIs(Touch expected)
            {
                this.expected = expected;
            }

            /// <inheritdoc/>
            public bool Detect(Touch signal)
            {
                return expected == signal;
            }
        }

        public sealed class PushIs :
            IDetection<Push>
        {
            public static PushIs Disabled { get; } = new PushIs(Push.Disabled);

            public static PushIs Enabled { get; } = new PushIs(Push.Enabled);

            private readonly Push expected;

            private PushIs(Push expected)
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
}
