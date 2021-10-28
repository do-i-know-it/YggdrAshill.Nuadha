using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Tilt"/>.
    /// </summary>
    public static class TiltInto
    {
        public sealed class PullBy :
            ITranslation<Tilt, Pull>
        {
            /// <summary>
            /// Converts <see cref="Tilt.Distance"/> into <see cref="Pull"/>.
            /// </summary>
            public static PullBy Distance { get; }
                = new PullBy(signal =>
                {
                    return signal.Distance.ToPull();
                });

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
            /// </summary>
            public static PullBy Left { get; }
                = new PullBy(signal =>
                {
                    return Math.Max(-signal.Horizontal, 0).ToPull();
                });

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
            /// </summary>
            public static PullBy Right { get; }
                = new PullBy(signal =>
                {
                    return Math.Max(signal.Horizontal, 0).ToPull();
                });

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
            /// </summary>
            public static PullBy Forward { get; }
                = new PullBy(signal =>
                {
                    return Math.Max(signal.Vertical, 0).ToPull();
                });

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
            /// </summary>
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
            public Pull Translate(Tilt signal)
            {
                return onConverted.Invoke(signal);
            }
        }

        public static class PushBy
        {
            /// <summary>
            /// Converts <see cref="Tilt.Distance"/> into <see cref="Push"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Distance"/> into <see cref="Push"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Push> Distance(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Distance.Then(PullInto.Push(threshold));
            }

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Push"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Horizontal"/> into <see cref="Push"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Push> Left(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Left.Then(PullInto.Push(threshold));
            }

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Push"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Horizontal"/> into <see cref="Push"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Push> Right(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Right.Then(PullInto.Push(threshold));
            }

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Push"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Vertical"/> into <see cref="Push"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Push> Forward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Forward.Then(PullInto.Push(threshold));
            }

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Push"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Vertical"/> into <see cref="Push"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Push> Backward(HysteresisThreshold threshold)
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
            /// <summary>
            /// Converts <see cref="Tilt.Distance"/> into <see cref="Pulse"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Distance"/> into <see cref="Pulse"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Pulse> Distance(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Distance(threshold).Then(PushInto.Pulse);
            }

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pulse"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Horizontal"/> into <see cref="Pulse"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Pulse> Left(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Left(threshold).Then(PushInto.Pulse);
            }

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pulse"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Horizontal"/> into <see cref="Pulse"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Pulse> Right(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Right(threshold).Then(PushInto.Pulse);
            }

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pulse"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Vertical"/> into <see cref="Pulse"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Pulse> Forward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PushBy.Forward(threshold).Then(PushInto.Pulse);
            }

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pulse"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Vertical"/> into <see cref="Pulse"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Pulse> Backward(HysteresisThreshold threshold)
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
