using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    public sealed class IntoAccuracyFrom<TSignal> : IConversion<TSignal, Accuracy<TSignal>>
        where TSignal : ISignal
    {
        private readonly IOffset<TSignal> offset;

        public IntoAccuracyFrom(IOffset<TSignal> offset)
        {
            this.offset = offset;
        }

        public Accuracy<TSignal> Convert(TSignal signal)
        {
            return new Accuracy<TSignal>(signal, offset.Value);
        }
    }
}
