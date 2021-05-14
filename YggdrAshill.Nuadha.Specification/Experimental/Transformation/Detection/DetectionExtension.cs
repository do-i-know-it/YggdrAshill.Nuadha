using YggdrAshill.Nuadha.Signalization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    /// <summary>
    /// Extensions for Detection.
    /// </summary>
    public static class DetectionExtension
    {
        /// <summary>
        /// Detects <see cref="Notice"/> from <typeparamref name="TSignal"/>.
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
        /// <see cref="IProduction{TSignal}"/> detected.
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

            return new Detector<TSignal>(production, detection);
        }

        /// <summary>
        /// Negate <see cref="IDetection{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to negate.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> negated.
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
        /// 
        /// </summary>
        /// <typeparam name="TSignal"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <typeparam name="TSignal"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
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
