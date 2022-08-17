using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines implementations of <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public static class That<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// When <typeparamref name="TSignal"/> is satisfied by <paramref name="detection"/>.
        /// </summary>
        /// <param name="detection">
        /// <see cref="Func{T, TResult}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IDetection<TSignal> Is(Func<TSignal, bool> detection)
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new ThatSignalIs(detection);
        }
        private sealed class ThatSignalIs :
            IDetection<TSignal>
        {
            private readonly Func<TSignal, bool> onDetected;

            public ThatSignalIs(Func<TSignal, bool> onDetected)
            {
                this.onDetected = onDetected;
            }

            public bool Detect(TSignal signal)
            {
                return onDetected.Invoke(signal);
            }
        }

        /// <summary>
        /// When <typeparamref name="TSignal"/> is not satisfied by <paramref name="detection"/>.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to invert.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> inverted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IDetection<TSignal> IsNot(IDetection<TSignal> detection)
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new ThatSignalIsNot(detection);
        }
        private sealed class ThatSignalIsNot :
            IDetection<TSignal>
        {
            private readonly IDetection<TSignal> detection;

            public ThatSignalIsNot(IDetection<TSignal> detection)
            {
                this.detection = detection;
            }

            public bool Detect(TSignal signal)
            {
                return !detection.Detect(signal);
            }
        }

        /// <summary>
        /// When <typeparamref name="TSignal"/> is satisfied by both <paramref name="first"/> and <paramref name="second"/>.
        /// </summary>
        /// <param name="first">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to multiply.
        /// </param>
        /// <param name="second">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to multiply.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static IDetection<TSignal> IsBoth(IDetection<TSignal> first, IDetection<TSignal> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new ThatSignalIsBoth(first, second);
        }
        private sealed class ThatSignalIsBoth :
            IDetection<TSignal>
        {
            private readonly IDetection<TSignal> first;

            private readonly IDetection<TSignal> second;

            public ThatSignalIsBoth(IDetection<TSignal> first, IDetection<TSignal> second)
            {
                this.first = first;

                this.second = second;
            }

            public bool Detect(TSignal signal)
            {
                return first.Detect(signal) && second.Detect(signal);
            }
        }

        /// <summary>
        /// When <typeparamref name="TSignal"/> is satisfied by either <paramref name="first"/> or <paramref name="second"/>.
        /// </summary>
        /// <param name="first">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to add.
        /// </param>
        /// <param name="second">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to add.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static IDetection<TSignal> IsEither(IDetection<TSignal> first, IDetection<TSignal> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new ThatSignalIsEither(first, second);
        }
        private sealed class ThatSignalIsEither :
            IDetection<TSignal>
        {
            private readonly IDetection<TSignal> first;

            private readonly IDetection<TSignal> second;

            public ThatSignalIsEither(IDetection<TSignal> first, IDetection<TSignal> second)
            {
                this.first = first;

                this.second = second;
            }

            public bool Detect(TSignal signal)
            {
                return first.Detect(signal) || second.Detect(signal);
            }
        }
    }
}
