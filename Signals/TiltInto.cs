using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public static class TiltInto
    {
        public sealed class PullBy :
            IConversion<Tilt, Pull>
        {
            public static PullBy Distance { get; }
                = new PullBy(signal =>
                {
                    return signal.Distance.ToPull();
                });

            public static PullBy Left { get; }
                = new PullBy(signal =>
                {
                    return Math.Max(-signal.Horizontal, 0).ToPull();
                });

            public static PullBy Right { get; }
                = new PullBy(signal =>
                {
                    return Math.Max(signal.Horizontal, 0).ToPull();
                });

            public static PullBy Forward { get; }
                = new PullBy(signal =>
                {
                    return Math.Max(signal.Vertical, 0).ToPull();
                });

            public static PullBy Backward { get; }
                = new PullBy(signal =>
                {
                    return Math.Max(-signal.Vertical, 0).ToPull();
                });

            private readonly Func<Tilt, Pull> onConverted;

            private PullBy(Func<Tilt, Pull> onConverted)
            {
                this.onConverted = onConverted;
            }

            /// <inheritdoc/>
            public Pull Convert(Tilt signal)
            {
                return onConverted.Invoke(signal);
            }
        }

        public sealed class PushBy :
            IConversion<Tilt, Push>
        {
            public static PushBy Distance(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PushBy(PullBy.Distance, threshold);
            }

            public static PushBy Left(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PushBy(PullBy.Left, threshold);
            }

            public static PushBy Right(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PushBy(PullBy.Right, threshold);
            }

            public static PushBy Forward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PushBy(PullBy.Forward, threshold);
            }

            public static PushBy Backward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PushBy(PullBy.Backward, threshold);
            }
            
            private readonly PullBy tiltToPull;

            private readonly IConversion<Pull, Push> pullToPush;

            private PushBy(PullBy tiltToPull, HysteresisThreshold threshold)
            {
                this.tiltToPull = tiltToPull;

                pullToPush = PullInto.Push(threshold);
            }

            /// <inheritdoc/>
            public Push Convert(Tilt signal)
            {
                var converted = tiltToPull.Convert(signal);

                return pullToPush.Convert(converted);
            }
        }

        public sealed class PulseBy :
            IPulsation<Tilt>
        {
            public static PulseBy Distance(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PulseBy(PullBy.Distance, threshold);
            }

            public static PulseBy Left(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PulseBy(PullBy.Left, threshold);
            }

            public static PulseBy Right(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PulseBy(PullBy.Right, threshold);
            }
            public static PulseBy Forward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PulseBy(PullBy.Forward, threshold);
            }
            public static PulseBy Backward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return new PulseBy(PullBy.Backward, threshold);
            }

            private readonly IConversion<Tilt, Pull> conversion;

            private readonly IPulsation<Pull> pulsation;

            private PulseBy(PullBy conversion, HysteresisThreshold threshold)
            {
                this.conversion = conversion;

                pulsation = PullInto.Pulse(threshold);
            }

            /// <inheritdoc/>
            public Pulse Pulsate(Tilt signal)
            {
                var converted = conversion.Convert(signal);

                return pulsation.Pulsate(converted);
            }
        }
    }
}
