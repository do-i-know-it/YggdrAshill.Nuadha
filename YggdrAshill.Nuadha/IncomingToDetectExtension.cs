using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IIncomingFlow{TSignal}"/> to detect.
    /// </summary>
    public static class IncomingToDetectExtension
    {
        /// <summary>
        /// Detects <see cref="Pulse"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="incomingFlow">
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIncomingFlow{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        public static IIncomingFlow<Pulse> Detect<TSignal>(this IIncomingFlow<TSignal> incomingFlow, IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            return new IncomingToDetectPulseFrom<TSignal>(incomingFlow, detection);
        }

        /// <summary>
        /// Detects <see cref="Pulse"/> of <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="incomingFlow">
        /// <see cref="IIncomingFlow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="onDetected">
        /// <see cref="Func{T, TResult}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IIncomingFlow{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        public static IIncomingFlow<Pulse> Detect<TSignal>(this IIncomingFlow<TSignal> incomingFlow, Func<TSignal, bool> onDetected)
            where TSignal : ISignal
        {
            var detection = new Detection<TSignal>(onDetected);
            return incomingFlow.Detect(detection);
        }
    }
}
