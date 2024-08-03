using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    public sealed class IntoSequenceFrom<TSignal> : IConversion<TSignal, Sequence<TSignal>>
        where TSignal : ISignal
    {
        private readonly ICache<TSignal> previous;

        public IntoSequenceFrom(ICache<TSignal> previous)
        {
            this.previous = previous;
        }

        public Sequence<TSignal> Convert(TSignal signal)
        {
            try
            {
                return new Sequence<TSignal>(previous.Value, signal);
            }
            finally
            {
                previous.Value = signal;
            }
        }
    }
}
