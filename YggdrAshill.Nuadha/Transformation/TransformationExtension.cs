using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    public static class TransformationExtension
    {
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, Func<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return production.Convert(new Conversion<TInput, TOutput>(conversion));
        }

        public static IProduction<TSignal> Convert<TSignal>(this IProduction<TSignal> production, Func<TSignal, TSignal> correction)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return production.Convert(new Correction<TSignal>(correction));
        }

        public static IProduction<Pulse> Convert<TSignal>(this IProduction<TSignal> production, Func<TSignal, Pulse> pulsation)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return production.Convert(new Pulsation<TSignal>(pulsation));
        }

        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, Func<TSignal, bool> detection)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return production.Detect(detection);
        }
    }
}
