using System;
using System.Collections.Generic;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public sealed class Flow<TSignal> : IFlow<TSignal>
        where TSignal : ISignal
    {
        private readonly List<IOutgoingFlow<TSignal>> outflowList = new List<IOutgoingFlow<TSignal>>();

        public IDisposable Import(IOutgoingFlow<TSignal> outgoingFlow)
        {
            if (!outflowList.Contains(outgoingFlow))
            {
                outflowList.Add(outgoingFlow);
            }

            return new Disposable(outflowList, outgoingFlow);
        }

        public void Export(TSignal signal)
        {
            foreach (var outflow in outflowList)
            {
                outflow.Export(signal);
            }
        }

        public void Dispose()
        {
            outflowList.Clear();
        }

        private sealed class Disposable : IDisposable
        {
            private readonly IList<IOutgoingFlow<TSignal>> outflowList;
            private readonly IOutgoingFlow<TSignal> outgoingFlow;

            public Disposable(IList<IOutgoingFlow<TSignal>> outflowList, IOutgoingFlow<TSignal> outgoingFlow)
            {
                this.outflowList = outflowList;
                this.outgoingFlow = outgoingFlow;
            }

            public void Dispose()
            {
                if (outflowList.Contains(outgoingFlow))
                {
                    outflowList.Remove(outgoingFlow);
                }
            }
        }
    }
}
