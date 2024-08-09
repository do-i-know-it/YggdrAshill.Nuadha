using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public sealed class OutgoingFlow<TSignal> : IOutgoingFlow<TSignal>
        where TSignal : ISignal
    {
        public static OutgoingFlow<TSignal> None { get; } = new(_ => { });

        private readonly Action<TSignal> onExported;

        public OutgoingFlow(Action<TSignal> onExported)
        {
            this.onExported = onExported;
        }

        public void Export(TSignal signal)
        {
            onExported.Invoke(signal);
        }
    }
}
