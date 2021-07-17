using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="Pulse"/>.
    /// </summary>
    public static class PulseExtension
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pulse"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to convert.
        /// </param>
        /// <param name="condition">
        /// <see cref="ICondition{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static IProduction<Pulse> Convert<TSignal>(this IProduction<TSignal> production, ICondition<TSignal> condition)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return production.Convert(PulseFrom.Signal(condition));
        }
    }
}
