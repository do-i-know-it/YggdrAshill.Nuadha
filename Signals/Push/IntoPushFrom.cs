using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Push"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    public static class IntoPushFrom<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Push"/> like <paramref name="conversion"/>.
        /// </summary>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TSignal"/> into <see cref="bool"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IConversion<TSignal, Push> Like(Func<TSignal, bool> conversion)
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return From<TSignal>.Into<Push>.Like(signal => (Push)conversion.Invoke(signal));
        }

        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Push"/>.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IConversion<TSignal, Push> When(IDetection<TSignal> detection)
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return From<TSignal>.Into<Push>.Like(signal => (Push)detection.Detect(signal));
        }
    }
}
