using YggdrAshill.Nuadha.Evaluation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public sealed class FlexibleValue<TSignal> : ICache<TSignal>, IThreshold<TSignal>, IOffset<TSignal>
        where TSignal : ISignal
    {
        public TSignal Value { get; set; }

        public FlexibleValue(TSignal signal)
        {
            Value = signal;
        }
    }
}
