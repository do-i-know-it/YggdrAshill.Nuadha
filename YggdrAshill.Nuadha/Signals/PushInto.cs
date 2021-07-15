using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class PushInto
    {
        public static IConversion<Push, Touch> Touch { get; } = SignalInto.Signal<Push, Touch>(signal => signal.ToBoolean().ToTouch());

        public static IConversion<Push, Pulse> Pulse { get; } = PulseFrom.Signal(PushIs.Enabled);
    }
}
