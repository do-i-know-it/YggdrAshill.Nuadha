using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines implementations of <see cref="IEmission"/> for Conduction.
    /// </summary>
    public static class ConductSignalTo
    {
        /// <summary>
        /// Sends <typeparamref name="TSignal"/> generated by <see cref="IGeneration{TSignal}"/> to <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to conduct.
        /// </typeparam>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to conduct.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to conduct.
        /// </param>
        /// <returns>
        /// <see cref="IEmission"/> to conduct.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IEmission Consume<TSignal>(IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
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

            return new Emission<TSignal>(generation, consumption);
        }
        private sealed class Emission<TSignal> :
            IEmission
            where TSignal : ISignal
        {
            private readonly IGeneration<TSignal> generation;

            private readonly IConsumption<TSignal> consumption;

            internal Emission(IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
            {
                this.generation = generation;

                this.consumption = consumption;
            }

            public void Emit()
            {
                var signal = generation.Generate();

                consumption.Consume(signal);
            }
        }
    }
}