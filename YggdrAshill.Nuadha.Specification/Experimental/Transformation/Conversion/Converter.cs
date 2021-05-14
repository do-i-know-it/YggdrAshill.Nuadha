using YggdrAshill.Nuadha.Signalization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    internal sealed class Converter<TInput, TOutput> :
        IProduction<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IProduction<TInput> production;

        private readonly IConversion<TInput, TOutput> conversion;

        internal Converter(IProduction<TInput> production, IConversion<TInput, TOutput> conversion)
        {
            this.production = production;

            this.conversion = conversion;
        }

        public ICancellation Produce(IConsumption<TOutput> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(new Convert<TInput, TOutput>(conversion, consumption));
        }
    }
}
