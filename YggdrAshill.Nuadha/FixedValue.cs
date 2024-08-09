using YggdrAshill.Nuadha.Evaluation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public sealed class FixedValue<TSignal> : IThreshold<TSignal>, IOffset<TSignal>
        where TSignal : ISignal
    {
        public TSignal Value { get; }

        public FixedValue(TSignal signal)
        {
            Value = signal;
        }
    }
}
