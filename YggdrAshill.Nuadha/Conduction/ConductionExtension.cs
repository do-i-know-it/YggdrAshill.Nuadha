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

        /// <summary>
        /// Collects <see cref="IEmission"/> to emit simultaneously.
        /// </summary>
        /// <param name="emission">
        /// <see cref="IEmission"/> collected.
        /// </param>
        /// <param name="composite">
        /// <see cref="CompositeEmission"/> to collect.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="emission"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="composite"/> is null.
        /// </exception>
        public static void Synthesize(this IEmission emission, CompositeEmission composite)
        {
            if (emission == null)
            {
                throw new ArgumentNullException(nameof(emission));
            }
            if (composite == null)
            {
                throw new ArgumentNullException(nameof(composite));
            }

            composite.Synthesize(emission);
        }
    }
}
