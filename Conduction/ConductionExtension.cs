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
        /// <see cref="IGeneration{TSignal}"/> to generate.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to send.
        /// </returns>
        public static IProduction<TSignal> ToProduction<TSignal>(this IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return new Production<TSignal>(generation);
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
        /// <see cref="IConsumption{TSignal}"/> to use.
        /// </param>
        /// <returns>
        /// <see cref="IEmission"/> to emit.
        /// </returns>
        public static IEmission Produce<TSignal>(this IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return new Emission<TSignal>(generation, consumption);
        }
    }
}
