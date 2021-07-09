using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Signalization.
    /// </summary>
    public static class SignalizationExtension
    {
        /// <summary>
        /// Converts <see cref="IPropagation{TSignal}"/> into <see cref="IConduction{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to propagate.
        /// </param>
        /// <param name="emission">
        /// <see cref="Func{TSignal}"/> executed when this has emitted.
        /// </param>
        /// <returns>
        /// <see cref="IConduction{TSignal}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="emission"/> is null.
        /// </exception>
        public static IConduction<TSignal> ToConduction<TSignal>(this IPropagation<TSignal> propagation, Func<TSignal> emission)
            where TSignal : ISignal
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (emission == null)
            {
                throw new ArgumentNullException(nameof(emission));
            }

            return new Conduction<TSignal>(propagation, emission);
        }
        private sealed class Conduction<TSignal> :
            IConduction<TSignal>
            where TSignal : ISignal
        {
            private readonly IPropagation<TSignal> propagation;

            private readonly Func<TSignal> emission;

            internal Conduction(IPropagation<TSignal> propagation, Func<TSignal> emission)
            {
                this.propagation = propagation;

                this.emission = emission;
            }

            #region IProduction

            /// <inheritdoc/>
            public ICancellation Produce(IConsumption<TSignal> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return propagation.Produce(consumption);
            }

            #endregion

            #region IEmission

            /// <inheritdoc/>
            public void Emit()
            {
                var signal = emission.Invoke();

                propagation.Consume(signal);
            }

            #endregion

            #region IDisposable

            /// <inheritdoc/>
            public void Dispose()
            {
                propagation.Dispose();
            }

            #endregion
        }

        /// <summary>
        /// Produces with <see cref="Action{TSignal}"/> instead of <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to send.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{TSignal}"/> to execute when this has consumed <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IEmission"/> to emit.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Produce<TSignal>(this IProduction<TSignal> production, Action<TSignal> consumption)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(new Consumption<TSignal>(consumption));
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
