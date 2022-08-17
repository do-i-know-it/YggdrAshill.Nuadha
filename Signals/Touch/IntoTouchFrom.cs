using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Touch"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    public static class IntoTouchFrom<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Touch"/> like <paramref name="conversion"/>.
        /// </summary>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TSignal"/> into <see cref="bool"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IConversion<TSignal, Touch> Like(Func<TSignal, bool> conversion)
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return From<TSignal>.Into<Touch>.Like(signal => (Touch)conversion.Invoke(signal));
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Touch"/>.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IConversion<TSignal, Touch> When(IDetection<TSignal> detection)
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return From<TSignal>.Into<Touch>.Like(signal => (Touch)detection.Detect(signal));
        }
    }
}
