using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Conduction.
    /// </summary>
    public static class ConductionExtension
    {
        /// <summary>
        /// Converts <see cref="IPropagation{TSignal}"/> into <see cref="ITransmission{TSignal}"/> with <see cref="Func{T}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to transmit.
        /// </typeparam>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to convert.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{T}"/> executed when this has generated.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<TSignal> ToConduction<TSignal>(this IPropagation<TSignal> propagation, Func<TSignal> generation)
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

            return propagation.Transmit(new Generation<TSignal>(generation));
        }
    }
}
