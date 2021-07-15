using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/>.
    /// </summary>
    public static class SignalTo
    {
        public static IConversion<TSignal, TSignal> Calibrate<TSignal>(ICalibration<TSignal> calibration, IGeneration<TSignal> generation)
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

            return new Calibration<TSignal>(calibration, generation);
        }
        private sealed class Calibration<TSignal> :
            IConversion<TSignal, TSignal>
            where TSignal : ISignal
        {
            private readonly ICalibration<TSignal> calibration;

            private readonly IGeneration<TSignal> generation;

            internal Calibration(ICalibration<TSignal> calibration, IGeneration<TSignal> generation)
            {
                this.calibration = calibration;

                this.generation = generation;
            }

            /// <inheritdoc/>
            public TSignal Convert(TSignal signal)
            {
                var offset = generation.Generate();

                return calibration.Calibrate(signal, offset);
            }
        }

        public static IConversion<TSignal, TSignal> Filtrate<TSignal>(IFiltration<TSignal> filtration, IGeneration<TSignal> generation)
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

            return new Filtration<TSignal>(filtration, generation);
        }
        private sealed class Filtration<TSignal> :
            IConversion<TSignal, TSignal>
            where TSignal : ISignal
        {
            private readonly IFiltration<TSignal> filtration;

            private TSignal previous;

            internal Filtration(IFiltration<TSignal> filtration, IGeneration<TSignal> generation)
            {
                this.filtration = filtration;

                previous = generation.Generate();
            }

            /// <inheritdoc/>
            public TSignal Convert(TSignal signal)
            {
                return previous = filtration.Filtrate(signal, previous);
            }
        }
    }
}
