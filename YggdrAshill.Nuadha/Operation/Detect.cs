using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha
{
    public static class Detect<TSignal>
        where TSignal : ISignal
    {
        public static IDetection<TSignal> All { get; }
            = new Detection<TSignal>(_ =>
            {
                return true;
            });

        public static IDetection<TSignal> None { get; }
            = new Detection<TSignal>(_ =>
            {
                return false;
            });
    }
}
