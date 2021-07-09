using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class SignalExtension
    {
        public static IProduction<Pulse> Convert(this IProduction<Touch> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            var detection = new Detection<Touch>(signal =>
            {
                return (bool)signal;
            });

            return production.Convert(IntoPulseFrom<Touch>.With(detection));
        }

        public static IProduction<Pulse> Convert(this IProduction<Push> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            var detection = new Detection<Push>(signal =>
            {
                return (bool)signal;
            });

            return production.Convert(IntoPulseFrom<Push>.With(detection));
        }

        public static IProduction<Pulse> Convert(this IProduction<Pull> production, HysteresisThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return production
                .Convert(PullToPush.With(threshold))
                .Convert();
        }

        public static IProduction<Pulse> Convert(this IProduction<Tilt> production, IConversion<Tilt, Pull> conversion, HysteresisThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return production
                .Convert(conversion)
                .Convert(PullToPush.With(threshold))
                .Convert();
        }
    }
}
