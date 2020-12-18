using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha
{
    public static class TranslationExtension
    {
        public static IOutputTerminal<TOutput> Convert<TInput, TOutput>(this IOutputTerminal<TInput> terminal, Func<TInput, TOutput> conversion)
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

            return terminal.Convert(new Conversion<TInput, TOutput>(conversion));
        }

        public static IOutputTerminal<TSignal> Correct<TSignal>(this IOutputTerminal<TSignal> terminal, Func<TSignal, TSignal> correction)
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

            return terminal.Correct(new Correction<TSignal>(correction));
        }

        public static IOutputTerminal<Pulse> Detect<TSignal>(this IOutputTerminal<TSignal> terminal, Func<TSignal, bool> detection)
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

            return terminal.Detect(new Detection<TSignal>(detection));
        }

        public static IOutputTerminal<TSignal> Calibrate<TSignal>(this IOutputTerminal<TSignal> terminal, Func<TSignal, TSignal, TSignal> reduction, Func<TSignal> calibration)
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

            return terminal.Calibrate(new Reduction<TSignal>(reduction), new Calibration<TSignal>(calibration));
        }

        public static IDisconnection Connect(this IOutputTerminal<Pulse> terminal, Action onReceived)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return terminal.Connect(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                onReceived.Invoke();
            });
        }
    }
}
