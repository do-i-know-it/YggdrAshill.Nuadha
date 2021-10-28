using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines extensions for <see cref="IPropagation{TSignal}"/>.
    /// </summary>
    public static class PropagationExtension
    {
        /// <summary>
        /// Creates <see cref="ITransmission{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to transmit.
        /// </typeparam>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to propagate <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> to transmit.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<TSignal> Transmit<TSignal>(this IPropagation<TSignal> propagation, IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return new Transmission<TSignal>(propagation, generation);
        }
        private sealed class Transmission<TSignal> :
            ITransmission<TSignal>
            where TSignal : ISignal
        {
            private readonly IPropagation<TSignal> propagation;

            private readonly IGeneration<TSignal> generation;

            internal Transmission(IPropagation<TSignal> propagation, IGeneration<TSignal> generation)
            {
                this.propagation = propagation;

                this.generation = generation;
            }

            public ICancellation Produce(IConsumption<TSignal> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return propagation.Produce(consumption);
            }

            public void Emit()
            {
                var signal = generation.Generate();

                propagation.Consume(signal);
            }

            public void Dispose()
            {
                propagation.Dispose();
            }
        }
    }
}
