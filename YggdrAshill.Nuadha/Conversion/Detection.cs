using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IDetection{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class Detection<TSignal> :
        IDetection<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Always detects <typeparamref name="TSignal"/>.
        /// </summary>
        public static IDetection<TSignal> All { get; }
            = new Detection<TSignal>(_ =>
            {
                return true;
            });

        /// <summary>
        /// Never detects <typeparamref name="TSignal"/>.
        /// </summary>
        public static IDetection<TSignal> None { get; }
            = new Detection<TSignal>(_ =>
            {
                return false;
            });

        private readonly Func<TSignal, bool> onDetected;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onDetected">
        /// <see cref="Func{TSignal, bool}"/> to execute when this has detected.
        /// </param>
        public Detection(Func<TSignal, bool> onDetected)
        {
            if (onDetected == null)
            {
                throw new ArgumentNullException(nameof(onDetected));
            }

            this.onDetected = onDetected;
        }

        /// <inheritdoc/>
        public bool Detect(TSignal signal)
        {
            return onDetected.Invoke(signal);
        }
    }
}
