using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Consumes <typeparamref name="TSignal"/> to detect <see cref="Pulse"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class ConsumeToDetect<TSignal> :
        IConsumption<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;

        private readonly IConsumption<Pulse> consumption;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Pulse"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public ConsumeToDetect(IDetection<TSignal> detection, IConsumption<Pulse> consumption)
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            this.detection = detection;

            this.consumption = consumption;
        }

        /// <summary>
        /// Consumes <paramref name="signal"/> to detect <see cref="Pulse"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to detect.
        /// </param>
        public void Consume(TSignal signal)
        {
            if (!detection.Detect(signal))
            {
                return;
            }

            consumption.Consume(new Pulse());
        }
    }
}
