using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    public static class TouchInto
    {
        public static IConversion<Touch, Push> Push => ConvertTouchIntoPush.Instance;
        private sealed class ConvertTouchIntoPush :
            IConversion<Touch, Push>
        {
            public static ConvertTouchIntoPush Instance { get; } = new ConvertTouchIntoPush();

            private ConvertTouchIntoPush()
            {

            }

            public Push Convert(Touch signal)
            {
                return signal.ToBoolean().ToPush();
            }
        }

        public static IPulsation<Touch> Pulse { get; } = SignalInto.Pulse(WhenTouch.IsEnabled);
    }
}
