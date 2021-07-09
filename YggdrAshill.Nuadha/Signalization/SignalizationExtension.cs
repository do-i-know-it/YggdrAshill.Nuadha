using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Extension for Signalization.
    /// </summary>
    public static class SignalizationExtension
    {
        /// <summary>
        /// Produces with <see cref="Action{TSignal}"/> instead of <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to send.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce.
        /// </param>
        /// <param name="onConsumed">
        /// <see cref="Action{TSignal}"/> to execute when this has consumed <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IEmission"/> to emit.
        /// </returns>
        public static ICancellation Produce<TSignal>(this IProduction<TSignal> production, Action<TSignal> onConsumed)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (onConsumed == null)
            {
                throw new ArgumentNullException(nameof(onConsumed));
            }

            return production.Produce(new Consumption<TSignal>(onConsumed));
        }

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

            synthesized.cancellations.Add(cancellation);
            synthesized.cancellations.Add(synthesized);
        }
    }
}
