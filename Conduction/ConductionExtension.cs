using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines extensions for Conduction.
    /// </summary>
    public static class ConductionExtension
    {
        /// <summary>
        /// Converts <see cref="IPropagation{TSignal}"/> into <see cref="ITransmission{TSignal}"/> with <see cref="IGeneration{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to emit.
        /// </typeparam>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to convert.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to convert.
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
        public static ITransmission<TSignal> Transmit<TSignal>(this IPropagation<TSignal> propagation, IGeneration<TSignal> generation)
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

            return new ConvertedFromPropagation<TSignal>(propagation, generation);
        }
        
        /// <summary>
        /// Collects <see cref="ICancellation"/> to cancel simultaneously.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="ICancellation"/> collected.
        /// </param>
        /// <param name="synthesized">
        /// <see cref="SynthesizedCancellation"/> to collect.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="synthesized"/> is null.
        /// </exception>
        public static void Synthesize(this ICancellation cancellation, SynthesizedCancellation synthesized)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }
            if (synthesized == null)
            {
                throw new ArgumentNullException(nameof(synthesized));
            }

            synthesized.Synthesize(cancellation);
        }
    }
}
