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
        public static class PullBy
        {
            /// <summary>
            /// Converts <see cref="Tilt.Distance"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Distance { get; }
                = SignalInto.Signal<Tilt, Pull>(signal =>
                {
                    return signal.Distance.ToPull();
                });

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Left { get; }
                = SignalInto.Signal<Tilt, Pull>(signal =>
                {
                    return Math.Max(-signal.Horizontal, 0).ToPull();
                });

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Right { get; }
                = SignalInto.Signal<Tilt, Pull>(signal =>
                {
                    return Math.Max(signal.Horizontal, 0).ToPull();
                });

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Forward { get; }
                = SignalInto.Signal<Tilt, Pull>(signal =>
                {
                    return Math.Max(signal.Vertical, 0).ToPull();
                });

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Backward { get; }
                = SignalInto.Signal<Tilt, Pull>(signal =>
                {
                    return Math.Max(-signal.Vertical, 0).ToPull();
                });
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

        public static class TouchBy
        {
            /// <summary>
            /// Converts <see cref="Tilt.Distance"/> into <see cref="Touch"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Distance"/> into <see cref="Touch"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Touch> Distance(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Distance.Then(PullInto.Touch(threshold));
            }

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Touch"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Horizontal"/> into <see cref="Touch"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Touch> Left(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Left.Then(PullInto.Touch(threshold));
            }

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Touch"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Horizontal"/> into <see cref="Touch"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Touch> Right(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Right.Then(PullInto.Touch(threshold));
            }

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Touch"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Vertical"/> into <see cref="Touch"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Touch> Forward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Forward.Then(PullInto.Touch(threshold));
            }

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Touch"/>.
            /// </summary>
            /// <param name="threshold">
            /// <see cref="HysteresisThreshold"/> to convert.
            /// </param>
            /// <returns>
            /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt.Vertical"/> into <see cref="Touch"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="threshold"/> is null.
            /// </exception>
            public static ITranslation<Tilt, Touch> Backward(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                return PullBy.Backward.Then(PullInto.Touch(threshold));
            }
        }
    }
}
