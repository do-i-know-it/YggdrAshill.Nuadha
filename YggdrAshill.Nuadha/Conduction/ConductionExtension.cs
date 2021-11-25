using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConductionExtension
    {
        public static IEmission Conduct<TSignal>(this IConsumption<TSignal> consumption, IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return ConductSignalTo.Consume(generation, consumption);
        }

        public static IEmission Conduct<TSignal>(this IConsumption<TSignal> consumption, Func<TSignal> generation)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return consumption.Conduct(Generate.Signal(generation));
        }
    }
}
