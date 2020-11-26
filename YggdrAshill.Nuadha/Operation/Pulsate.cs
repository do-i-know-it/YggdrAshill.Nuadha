using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha
{
    public static class Pulsate<TSignal>
        where TSignal : ISignal
    {
        public static IPulsation<TSignal> All { get; }
            = new Pulsation<TSignal>((previous, current) =>
            {
                return true;
            });

        public static IPulsation<TSignal> None { get; }
            = new Pulsation<TSignal>((previous, current) =>
            {
                return false;
            });
    }
}
