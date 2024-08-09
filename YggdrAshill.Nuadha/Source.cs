using System;
using System.Collections.Generic;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public sealed class Source<TSignal> : ISource<TSignal>
        where TSignal : ISignal
    {
        private readonly IEqualityComparer<TSignal> comparer;
        private readonly Flow<TSignal> flow = new();

        public TSignal Value { get; private set; }

        public Source(IEqualityComparer<TSignal> comparer, TSignal initial)
        {
            this.comparer = comparer;
            Value = initial;
        }

        public Source(TSignal initial) : this(EqualityComparer<TSignal>.Default, initial)
        {

        }

        public IDisposable Import(IOutgoingFlow<TSignal> outgoingFlow)
        {
            outgoingFlow.Export(Value);
            return flow.Import(outgoingFlow);
        }

        public void Export(TSignal signal)
        {
            var previous = Value;
            Value = signal;
            if (!comparer.Equals(previous, signal))
            {
                flow.Export(signal);
            }
        }

        public void Dispose()
        {
            flow.Dispose();
        }

        public TSignal State
        {
            get => Value;
            set => Export(value);
        }
    }
}
