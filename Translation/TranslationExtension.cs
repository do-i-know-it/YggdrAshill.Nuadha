using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Translation
{
    public static class TranslationExtension
    {
        public static IOutputTerminal<TOutput> Convert<TInput, TOutput>(this IOutputTerminal<TInput> terminal, IConversion<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return new Converter<TInput, TOutput>(terminal, conversion);
        }

        public static IOutputTerminal<TSignal> Correct<TSignal>(this IOutputTerminal<TSignal> terminal, ICorrection<TSignal> correction)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return terminal.Convert(new Corrector<TSignal>(correction));
        }

        public static IOutputTerminal<TSignal> Calibrate<TSignal>(this IOutputTerminal<TSignal> terminal, IReduction<TSignal> reduction, ICalibration<TSignal> calibration)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (reduction == null)
            {
                throw new ArgumentNullException(nameof(reduction));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return terminal.Correct(new Calibrator<TSignal>(reduction, calibration));
        }

        public static IOutputTerminal<Pulse> Detect<TSignal>(this IOutputTerminal<TSignal> terminal, IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Detector<TSignal>(terminal, detection);
        }
    }
}
