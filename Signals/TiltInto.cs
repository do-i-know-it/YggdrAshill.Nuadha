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

        public static class PushBy
        {
            public static IConversion<Tilt, Push> Distance(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Distance.Then(PullInto.Push(threshold));
            }

            public static IConversion<Tilt, Push> Left(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Left.Then(PullInto.Push(threshold));
            }

            public static IConversion<Tilt, Push> Right(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Right.Then(PullInto.Push(threshold));
            }

            public static IConversion<Tilt, Push> Forward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Forward.Then(PullInto.Push(threshold));
            }

            public static IConversion<Tilt, Push> Backward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Backward.Then(PullInto.Push(threshold));
            }
        }

        public static class PulseBy
        {
            public static IConversion<Tilt, Pulse> Distance(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Distance(threshold).Then(PushInto.Pulse);
            }

            public static IConversion<Tilt, Pulse> Left(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Left(threshold).Then(PushInto.Pulse);
            }

            public static IConversion<Tilt, Pulse> Right(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Right(threshold).Then(PushInto.Pulse);
            }
            public static IConversion<Tilt, Pulse> Forward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Forward(threshold).Then(PushInto.Pulse);
            }
            public static IConversion<Tilt, Pulse> Backward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Backward(threshold).Then(PushInto.Pulse);
            }
        }
    }
}
