using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations for <see cref="IDetection{TSignal}"/>.
    /// </summary>
    public sealed class NoticeOf
    {
        /// <summary>
        /// Detects <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="detection">
        /// <see cref="Func{T, TResult}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IDetection<TSignal> Signal<TSignal>(Func<TSignal, bool> detection)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Detection<TSignal>(detection);
        }
        private sealed class Detection<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal, bool> detection;

            internal Detection(Func<TSignal, bool> detection)
            {
                this.detection = detection;
            }

            /// <inheritdoc/>
            public bool Detect(TSignal signal)
            {
                return detection.Invoke(signal);
            }
        }

        /// <summary>
        /// Detects all of <typeparamref name="TSignal"/> even if <typeparamref name="TSignal"/> is <see cref="null"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> created.
        /// </returns>
        public static IDetection<TSignal> All<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => true);
        }

        /// <summary>
        /// Detects none of <typeparamref name="TSignal"/> even if <typeparamref name="TSignal"/> is <see cref="null"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> created.
        /// </returns>
        public static IDetection<TSignal> None<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => false);
        }
    }
}
