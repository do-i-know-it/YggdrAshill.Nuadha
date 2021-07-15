using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class TouchInto
    {
        public static IConversion<Touch, Push> Push { get; } = SignalInto.Signal<Touch, Push>(signal => signal.ToBoolean().ToPush());

        public static IConversion<Touch, Pulse> Pulse { get; } = PulseFrom.Signal(TouchIs.Enabled);
    }
}
