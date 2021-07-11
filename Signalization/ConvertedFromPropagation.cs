using System;

namespace YggdrAshill.Nuadha.Signalization
{
    internal sealed class ConvertedFromPropagation<TSignal> :
        ITransmission<TSignal>
        where TSignal : ISignal
    {
        private readonly IPropagation<TSignal> propagation;

        private readonly IGeneration<TSignal> generation;

        internal ConvertedFromPropagation(IPropagation<TSignal> propagation, IGeneration<TSignal> generation)
        {
            this.propagation = propagation;

            this.generation = generation;
        }

        #region IProduction

        /// <inheritdoc/>
        public ICancellation Produce(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return propagation.Produce(consumption);
        }

        #endregion

        #region IEmission

        /// <inheritdoc/>
        public void Emit()
        {
            var gemerated = generation.Generate();

            propagation.Consume(gemerated);
        }

        #endregion

        #region IDisposable

        /// <inheritdoc/>
        public void Dispose()
        {
            propagation.Dispose();
        }

        #endregion
    }
}
