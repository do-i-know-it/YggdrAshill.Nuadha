using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public sealed class IncomingFlow<TSignal> : IIncomingFlow<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<IOutgoingFlow<TSignal>, IDisposable> onImported;

        public IncomingFlow(Func<IOutgoingFlow<TSignal>, IDisposable> onImported)
        {
            this.onImported = onImported;
        }

        public IDisposable Import(IOutgoingFlow<TSignal> message)
        {
            return onImported.Invoke(message);
        }
    }
}
