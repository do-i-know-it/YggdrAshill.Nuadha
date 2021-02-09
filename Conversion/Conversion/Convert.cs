using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    internal sealed class Convert<TInput, TOutput> :
        IConsumption<TInput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConsumption<TOutput> consumption;

        private readonly IConversion<TInput, TOutput> conversion;

        internal Convert(IConsumption<TOutput> consumption, IConversion<TInput, TOutput> conversion)
        {
            this.consumption = consumption;

            this.conversion = conversion;
        }

        public void Consume(TInput signal)
        {
            var converted = conversion.Convert(signal);

            consumption.Consume(converted);
        }
    }
}
