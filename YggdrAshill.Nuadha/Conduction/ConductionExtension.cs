using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPropagation{TSignal}"/>.
    /// </summary>
    public static class ConductionExtension
    {
        /// <summary>
        /// Creates <see cref="ITransmission{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to transmit.
        /// </typeparam>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to propagate <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to generate <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> to transmit.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<TSignal> Transmit<TSignal>(this IPropagation<TSignal> propagation, Func<TSignal> generation)
            where TSignal : ISignal
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return propagation.Transmit(Generate.Signal(generation));
        }
    }
}
