using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Produces <see cref="Pulse"/> detected from <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class ProduceToDetect<TSignal> :
        IProduction<Pulse>
        where TSignal : ISignal
    {
        private readonly IProduction<TSignal> production;

        private readonly IDetection<TSignal> detection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public ProduceToDetect(IProduction<TSignal> production, IDetection<TSignal> detection)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            this.production = production;

            this.detection = detection;
        }

        /// <summary>
        /// Produces <see cref="Pulse"/> detected.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Pulse"/> detected from <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel sending.
        /// </returns>
        public ICancellation Produce(IConsumption<Pulse> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(new ConsumeToDetect<TSignal>(detection, consumption));
        }
    }
}
