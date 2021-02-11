using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Conversion
{
    internal sealed class Correct<TSignal> :
        ITranslation<TSignal, TSignal>
        where TSignal : ISignal
    {
        private readonly ICalculation<TSignal> calculation;

        private readonly IGeneration<TSignal> generation;

        public Correct(ICalculation<TSignal> calculation, IGeneration<TSignal> generation)
        {
            this.calculation = calculation;

            this.generation = generation;
        }

        public TSignal Translate(TSignal signal)
        {
            var offset = generation.Generate();

            return calculation.Calculate(signal, offset);
        }
    }
}
