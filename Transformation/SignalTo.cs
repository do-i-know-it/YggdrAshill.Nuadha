using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    public static class SignalTo
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TMedium"/> before converting <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> converted into <typeparamref name="TMedium"/>.
        /// </typeparam>
        /// <typeparam name="TMedium">
        /// Type of <see cref="ISignal"/> converted into <typeparamref name="TOutput"/>.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TMedium"/>.
        /// </typeparam>
        /// <param name="inputToMedium">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TMedium"/>.
        /// </param>
        /// <param name="mediumToOutput">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="inputToMedium"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediumToOutput"/> is null.
        /// </exception>
        public static ITranslation<TInput, TOutput> Transit<TInput, TMedium, TOutput>(ITranslation<TInput, TMedium> inputToMedium, ITranslation<TMedium, TOutput> mediumToOutput)
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            if (inputToMedium == null)
            {
                throw new ArgumentNullException(nameof(inputToMedium));
            }
            if (mediumToOutput == null)
            {
                throw new ArgumentNullException(nameof(mediumToOutput));
            }

            return new TranslateToTransit<TInput, TMedium, TOutput>(inputToMedium, mediumToOutput);
        }
        private sealed class TranslateToTransit<TInput, TMedium, TOutput> :
            ITranslation<TInput, TOutput>
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            private readonly ITranslation<TInput, TMedium> inputToMedium;

            private readonly ITranslation<TMedium, TOutput> mediumToOutput;

            internal TranslateToTransit(ITranslation<TInput, TMedium> inputToMedium, ITranslation<TMedium, TOutput> mediumToOutput)
            {
                this.inputToMedium = inputToMedium;

                this.mediumToOutput = mediumToOutput;
            }

            public TOutput Translate(TInput signal)
            {
                var translated = inputToMedium.Translate(signal);

                return mediumToOutput.Translate(translated);
            }
        }

        /// <summary>
        /// Calibrates <typeparamref name="TSignal"/> to correct.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to calibrate.
        /// </typeparam>
        /// <param name="calibration">
        /// <see cref="ICalibration{TSignal}"/> to calibrate.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate offset of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to calibrate <typeparamref name="TSignal"/>.
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

            return new TranslateToCalibrate<TSignal>(generation, calibration);
        }
        private sealed class TranslateToCalibrate<TSignal> :
            ITranslation<TSignal, TSignal>
                where TSignal : ISignal
        {
            private readonly IGeneration<TSignal> generation;

            private readonly ICalibration<TSignal> calibration;

            internal TranslateToCalibrate(IGeneration<TSignal> generation, ICalibration<TSignal> calibration)
            {
                this.generation = generation;

                this.calibration = calibration;
            }

            public TSignal Translate(TSignal signal)
            {
                var offset = generation.Generate();

                return calibration.Calibrate(signal, offset);
            }
        }

        /// <summary>
        /// Filtrates <typeparamref name="TSignal"/> to correct.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to filtrate.
        /// </typeparam>
        /// <param name="filtration">
        /// <see cref="IFiltration{TSignal}"/> to filtrate.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to initialize <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to filtrate <typeparamref name="TSignal"/>.
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

            return new TranslateToFiltrate<TSignal>(filtration, generation.Generate());
        }
        private sealed class TranslateToFiltrate<TSignal> :
            ITranslation<TSignal, TSignal>
            where TSignal : ISignal
        {
            private readonly IFiltration<TSignal> filtration;

            private TSignal previous;

            internal TranslateToFiltrate(IFiltration<TSignal> filtration, TSignal previous)
            {
                this.filtration = filtration;

                this.previous = previous;
            }

            public TSignal Translate(TSignal signal)
            {
                return previous = filtration.Filtrate(signal, previous);
            }
        }
    }
}
