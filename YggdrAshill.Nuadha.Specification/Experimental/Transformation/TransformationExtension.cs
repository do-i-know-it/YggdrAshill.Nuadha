using YggdrAshill.Nuadha.Signalization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    public static class TransformationExtension
    {
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, IConversion<TInput, TOutput> conversion)
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

            return new Converter<TInput, TOutput>(production, conversion);
        }

        public static IProduction<TSignal> Convert<TSignal>(this IProduction<TSignal> production, ICorrection<TSignal> correction)
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

            return production.Convert(new Correct<TSignal>(correction));
        }

        public static IProduction<Pulse> Convert<TSignal>(this IProduction<TSignal> production, IPulsation<TSignal> pulsation)
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

            return production.Convert(new Pulsate<TSignal>(pulsation));
        }

        public static IProduction<Notice> Detect<TSignal>(this IProduction<TSignal> production, IDetection<TSignal> detection)
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

            return new Detector<TSignal>(production, detection);
        }
    }
}
