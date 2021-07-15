using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="IDetection{TSignal}"/>.
    /// </summary>
    public static class DetectionExtension
    {
        /// <summary>
        /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to detect.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Notice"/> detected.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Production<TSignal>(production, detection);
        }
        private sealed class Production<TSignal> :
            IProduction<Notice>
            where TSignal : ISignal
        {
            private readonly IProduction<TSignal> production;

            private readonly IDetection<TSignal> detection;

            internal Production(IProduction<TSignal> production, IDetection<TSignal> detection)
            {
                this.production = production;

                this.detection = detection;
            }

            /// <inheritdoc/>
            public ICancellation Produce(IConsumption<Notice> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return production.Produce(new Consumption<TSignal>(detection, consumption));
            }
        }
        private sealed class Consumption<TSignal> :
            IConsumption<TSignal>
            where TSignal : ISignal
        {
            private readonly IDetection<TSignal> detection;

            private readonly IConsumption<Notice> consumption;

            internal Consumption(IDetection<TSignal> detection, IConsumption<Notice> consumption)
            {
                this.detection = detection;

                this.consumption = consumption;
            }

            /// <inheritdoc/>
            public void Consume(TSignal signal)
            {
                if (detection.Detect(signal))
                {
                    consumption.Consume(null);
                }
            }
        }

        /// <summary>
        /// Inverts <see cref="IDetection{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to invert.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> inverted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IDetection<TSignal> Not<TSignal>(this IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Invert<TSignal>(detection);
        }
        private sealed class Invert<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly IDetection<TSignal> detection;

            internal Invert(IDetection<TSignal> detection)
            {
                this.detection = detection;
            }

            public bool Detect(TSignal signal)
            {
                return !detection.Detect(signal);
            }
        }

        /// <summary>
        /// Multiplies two instances of <see cref="IDetection{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        public static IDetection<TSignal> And<TSignal>(this IDetection<TSignal> left, IDetection<TSignal> right)
            where TSignal : ISignal
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Multiply<TSignal>(left, right);
        }
        private sealed class Multiply<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly IDetection<TSignal> left;

            private readonly IDetection<TSignal> right;

            internal Multiply(IDetection<TSignal> left, IDetection<TSignal> right)
            {
                this.left = left;

                this.right = right;
            }

            public bool Detect(TSignal signal)
            {
                return left.Detect(signal) && right.Detect(signal);
            }
        }

        /// <summary>
        /// Adds two instances of <see cref="IDetection{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        public static IDetection<TSignal> Or<TSignal>(this IDetection<TSignal> left, IDetection<TSignal> right)
            where TSignal : ISignal
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return new Add<TSignal>(left, right);
        }
        private sealed class Add<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly IDetection<TSignal> left;

            private readonly IDetection<TSignal> right;

            internal Add(IDetection<TSignal> left, IDetection<TSignal> right)
            {
                this.left = left;

                this.right = right;
            }

            public bool Detect(TSignal signal)
            {
                return left.Detect(signal) || right.Detect(signal);
            }
        }
    }
}
