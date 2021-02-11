using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Extension for Conduction.
    /// </summary>
    public static class ConductionExtension
    {
        /// <summary>
        /// Converts <see cref="IGeneration{TSignal}"/> to <see cref="IProduction{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to send.
        /// </typeparam>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IProduction<TSignal> ToProduction<TSignal>(this IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return new ProductionWithGeneration<TSignal>(generation);
        }

        /// <summary>
        /// Produces <typeparamref name="TSignal"/> to <see cref="IConsumption{TSignal}"/> with <see cref="IGeneration{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to send.
        /// </typeparam>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to use <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IEmission"/> to emit.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IEmission Produce<TSignal>(this IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new EmissionWithGeneration<TSignal>(generation, consumption);
        }

        /// <summary>
        /// Converts <see cref="IProduction{TSignal}"/> to <see cref="IIgnition"/> with <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal"></typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to convert.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to use <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IIgnition ToIgnition<TSignal>(this IProduction<TSignal> production, IConsumption<TSignal> consumption)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new IgnitionWithProduction<TSignal>(production, consumption);
        }

        /// <summary>
        /// Converts <see cref="IGeneration{TSignal}"/> to <see cref="IIgnition"/> with <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal"></typeparam>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to convert.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to use <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IIgnition ToIgnition<TSignal>(this IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new IgnitionWithGeneration<TSignal>(generation, consumption);
        }
    }
}
