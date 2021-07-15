using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class TouchIs
    {
        public static IDetection<Touch> Disabled { get; } = NoticeOf.Signal<Touch>(signal => signal == Touch.Disabled);

        public static IDetection<Touch> Enabled { get; } = NoticeOf.Signal<Touch>(signal => signal == Touch.Enabled);
    }
}
