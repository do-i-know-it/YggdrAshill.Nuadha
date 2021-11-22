using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Conduction.
    /// </summary>
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

            return Conduction.Conduct.Signal(generation, consumption);
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
