using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Extensions for Detection.
    /// </summary>
    public static class DetectionExtension
    {
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

            public Invert(IDetection<TSignal> detection)
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

            return new Product<TSignal>(left, right);
        }
        private sealed class Product<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly IDetection<TSignal> left;

            private readonly IDetection<TSignal> right;

            public Product(IDetection<TSignal> left, IDetection<TSignal> right)
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

            return new Sum<TSignal>(left, right);
        }
        private sealed class Sum<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly IDetection<TSignal> left;

            private readonly IDetection<TSignal> right;

            public Sum(IDetection<TSignal> left, IDetection<TSignal> right)
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
