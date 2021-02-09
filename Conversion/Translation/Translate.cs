using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    internal sealed class Translate<TInput, TOutput> :
        IConsumption<TInput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConsumption<TOutput> consumption;

        private readonly ITranslation<TInput, TOutput> translation;

        internal Translate(IConsumption<TOutput> consumption, ITranslation<TInput, TOutput> translation)
        {
            this.consumption = consumption;

            this.translation = translation;
        }

        public void Consume(TInput signal)
        {
            var translated = translation.Translate(signal);

            consumption.Consume(translated);
        }
    }
}
