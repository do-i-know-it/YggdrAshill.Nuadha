using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    public static class SignalIntoSignal
    {
        public static class SignalTo
        {
            /// <summary>
            /// Calibrates <typeparamref name="TSignal"/> to correct.
            /// </summary>
            /// <typeparam name="TSignal">
            /// Type of <see cref="ISignal"/> to correct.
            /// </typeparam>
            /// <param name="calibration">
            /// <see cref="ICalibration{TSignal}"/> to correct.
            /// </param>
            /// <param name="generation">
            /// <see cref="IGeneration{TSignal}"/> to generate offset of <typeparamref name="TSignal"/>.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to correct <typeparamref name="TSignal"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="calibration"/> is null.
            /// </exception>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="generation"/> is null.
            /// </exception>
            public static ITranslation<TSignal, TSignal> Correct<TSignal>(ICalibration<TSignal> calibration, IGeneration<TSignal> generation)
                where TSignal : ISignal
            {
                if (calibration == null)
                {
                    throw new ArgumentNullException(nameof(calibration));
                }
                if (generation == null)
                {
                    throw new ArgumentNullException(nameof(generation));
                }

                return SignalInto.Signal<TSignal, TSignal>(signal =>
                {
                    var offset = generation.Generate();

                    return calibration.Calibrate(signal, offset);
                });
            }

            /// <summary>
            /// Corrects <typeparamref name="TSignal"/> to filtrate.
            /// </summary>
            /// <typeparam name="TSignal">
            /// Type of <see cref="ISignal"/> to correct.
            /// </typeparam>
            /// <param name="filtration">
            /// <see cref="IFiltration{TSignal}"/> to correct.
            /// </param>
            /// <param name="generation">
            /// <see cref="IGeneration{TSignal}"/> to initialize <typeparamref name="TSignal"/>.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to correct <typeparamref name="TSignal"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="filtration"/> is null.
            /// </exception>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="generation"/> is null.
            /// </exception>
            public static ITranslation<TSignal, TSignal> Correct<TSignal>(IFiltration<TSignal> filtration, IGeneration<TSignal> generation)
                where TSignal : ISignal
            {
                if (filtration == null)
                {
                    throw new ArgumentNullException(nameof(filtration));
                }
                if (generation == null)
                {
                    throw new ArgumentNullException(nameof(generation));
                }

                return new Translation<TSignal>(filtration, generation);
            }
            private sealed class Translation<TSignal> :
                ITranslation<TSignal, TSignal>
                where TSignal : ISignal
            {
                private readonly IFiltration<TSignal> filtration;

                private TSignal previous;

                internal Translation(IFiltration<TSignal> filtration, IGeneration<TSignal> generation)
                {
                    this.filtration = filtration;

                    previous = generation.Generate();
                }

                /// <inheritdoc/>
                public TSignal Translate(TSignal signal)
                {
                    return previous = filtration.Filtrate(signal, previous);
                }
            }
        }
    }
}
