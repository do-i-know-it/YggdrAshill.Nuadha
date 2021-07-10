using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    public static class PushInto
    {
        public static IConversion<Push, Touch> Touch => ConvertPushIntoTouch.Instance;
        private sealed class ConvertPushIntoTouch :
            IConversion<Push, Touch>
        {
            public static ConvertPushIntoTouch Instance { get; } = new ConvertPushIntoTouch();

            private ConvertPushIntoTouch()
            {

            }

            public Touch Convert(Push signal)
            {
                return signal.ToBoolean().ToTouch();
            }
        }

        public static IPulsation<Push> Pulse { get; } = SignalInto.Pulse(WhenPush.IsEnabled);
    }
}
