using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class PushIs
    {
        public static IDetection<Push> Disabled { get; } = NoticeOf.Signal<Push>(signal => signal == Push.Disabled);

        public static IDetection<Push> Enabled { get; } = NoticeOf.Signal<Push>(signal => signal == Push.Enabled);
    }
}
