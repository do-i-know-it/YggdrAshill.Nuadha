using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    public sealed class IntoContrastFrom<TSignal> : IConversion<TSignal, Contrast<TSignal>>
        where TSignal : ISignal
    {
        private readonly IThreshold<TSignal> threshold;

        public IntoContrastFrom(IThreshold<TSignal> threshold)
        {
            this.threshold = threshold;
        }

        public Contrast<TSignal> Convert(TSignal signal)
        {
            return new Contrast<TSignal>(threshold.Value, signal);
        }
    }
}
