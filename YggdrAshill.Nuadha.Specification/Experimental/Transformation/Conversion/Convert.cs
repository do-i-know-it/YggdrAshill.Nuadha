using YggdrAshill.Nuadha.Signalization.Experimental;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    internal sealed class Convert<TInput, TOutput> :
        IConsumption<TInput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConversion<TInput, TOutput> conversion;

        private readonly IConsumption<TOutput> consumption;

        internal Convert(IConversion<TInput, TOutput> conversion, IConsumption<TOutput> consumption)
        {
            this.conversion = conversion;

            this.consumption = consumption;
        }

        public void Consume(TInput signal)
        {
            var converted = conversion.Convert(signal);

            consumption.Consume(converted);
        }
    }
}
