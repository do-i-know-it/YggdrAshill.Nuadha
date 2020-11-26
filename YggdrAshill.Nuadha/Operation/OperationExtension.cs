using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha
{
    public static class OperationExtension
    {
        #region Conversion

        public static IOutputTerminal<TOutput> Convert<TInput, TOutput>(this IOutputTerminal<TInput> terminal, IConversion<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (terminal == null)
            {
                throw new System.ArgumentNullException(nameof(terminal));
            }
            if (conversion == null)
            {
                throw new System.ArgumentNullException(nameof(conversion));
            }

            return new Converter<TInput, TOutput>(terminal, conversion);
        }

        public static IOutputTerminal<TOutput> Convert<TInput, TOutput>(this IOutputTerminal<TInput> terminal, System.Func<TInput, TOutput> onConverted)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (terminal == null)
            {
                throw new System.ArgumentNullException(nameof(terminal));
            }
            if (onConverted == null)
            {
                throw new System.ArgumentNullException(nameof(onConverted));
            }

            return terminal.Convert(new Conversion<TInput, TOutput>(onConverted));
        }

        #endregion

        #region Correction

        public static IOutputTerminal<TSignal> Correct<TSignal>(this IOutputTerminal<TSignal> terminal, ICorrection<TSignal> correction)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new System.ArgumentNullException(nameof(terminal));
            }
            if (correction == null)
            {
                throw new System.ArgumentNullException(nameof(correction));
            }

            return new Corrector<TSignal>(terminal, correction);
        }

        public static IOutputTerminal<TSignal> Correct<TSignal>(this IOutputTerminal<TSignal> terminal, System.Func<TSignal, TSignal> onCorrected)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new System.ArgumentNullException(nameof(terminal));
            }
            if (onCorrected == null)
            {
                throw new System.ArgumentNullException(nameof(onCorrected));
            }

            return terminal.Correct(new Correction<TSignal>(onCorrected));
        }

        #endregion

        #region Detection

        public static IOutputTerminal<TSignal> Detect<TSignal>(this IOutputTerminal<TSignal> terminal, IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new System.ArgumentNullException(nameof(terminal));
            }
            if (detection == null)
            {
                throw new System.ArgumentNullException(nameof(detection));
            }

            return new Detector<TSignal>(terminal, detection);
        }

        public static IOutputTerminal<TSignal> Detect<TSignal>(this IOutputTerminal<TSignal> terminal, System.Func<TSignal, bool> onDetected)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new System.ArgumentNullException(nameof(terminal));
            }
            if (onDetected == null)
            {
                throw new System.ArgumentNullException(nameof(onDetected));
            }

            return terminal.Detect(new Detection<TSignal>(onDetected));
        }

        #endregion

        #region Pulsation

        public static IOutputTerminal<Pulse> Pulsate<TSignal>(this IOutputTerminal<TSignal> terminal, IPulsation<TSignal> pulsation, TSignal initial)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new System.ArgumentNullException(nameof(terminal));
            }
            if (pulsation == null)
            {
                throw new System.ArgumentNullException(nameof(pulsation));
            }

            return new Pulsator<TSignal>(terminal, pulsation, initial);
        }

        public static IOutputTerminal<Pulse> Pulsate<TSignal>(this IOutputTerminal<TSignal> terminal, System.Func<TSignal, TSignal, bool> onPulsated, TSignal initial)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new System.ArgumentNullException(nameof(terminal));
            }
            if (onPulsated == null)
            {
                throw new System.ArgumentNullException(nameof(onPulsated));
            }

            return terminal.Pulsate(new Pulsation<TSignal>(onPulsated), initial);
        }

        #endregion
    }
}
