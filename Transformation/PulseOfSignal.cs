using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="IDetection{TSignal}"/>.
    /// </summary>
    public static class PulseOfSignal
    {
        public static class Is
        {
            /// <summary>
            /// When <see cref="Pulse"/> converted from <typeparamref name="TSignal"/> is <see cref="Pulse.HasDisabled"/> or <see cref="Pulse.IsDisabled"/>.
            /// </summary>
            /// <typeparam name="TSignal">
            /// Type of <see cref="ISignal"/> to detect.
            /// </typeparam>
            /// <param name="conversion">
            /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
            /// </param>
            /// <returns>
            /// <see cref="IDetection{TSignal}"/> to detect.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="conversion"/> is null.
            /// </exception>
            public static IDetection<TSignal> Disabled<TSignal>(IConversion<TSignal, Pulse> conversion)
                where TSignal : ISignal
            {
                if (conversion == null)
                {
                    throw new ArgumentNullException(nameof(conversion));
                }

                return new Detection<TSignal>(conversion, PulseIs.Disabled);
            }

            /// <summary>
            /// When <see cref="Pulse"/> converted from <typeparamref name="TSignal"/> is <see cref="Pulse.HasEnabled"/> or <see cref="Pulse.IsEnabled"/>.
            /// </summary>
            /// <typeparam name="TSignal">
            /// Type of <see cref="ISignal"/> to detect.
            /// </typeparam>
            /// <param name="conversion">
            /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
            /// </param>
            /// <returns>
            /// <see cref="IDetection{TSignal}"/> to detect.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="conversion"/> is null.
            /// </exception>
            public static IDetection<TSignal> Enabled<TSignal>(IConversion<TSignal, Pulse> conversion)
                where TSignal : ISignal
            {
                if (conversion == null)
                {
                    throw new ArgumentNullException(nameof(conversion));
                }

                return new Detection<TSignal>(conversion, PulseIs.Enabled);
            }
        }

        public static class Has
        {
            /// <summary>
            /// When <see cref="Pulse"/> converted from <typeparamref name="TSignal"/> is <see cref="Pulse.HasDisabled"/>.
            /// </summary>
            /// <typeparam name="TSignal">
            /// Type of <see cref="ISignal"/> to detect.
            /// </typeparam>
            /// <param name="conversion">
            /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
            /// </param>
            /// <returns>
            /// <see cref="IDetection{TSignal}"/> to detect.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="conversion"/> is null.
            /// </exception>
            public static IDetection<TSignal> Disabled<TSignal>(IConversion<TSignal, Pulse> conversion)
                where TSignal : ISignal
            {
                if (conversion == null)
                {
                    throw new ArgumentNullException(nameof(conversion));
                }

                return new Detection<TSignal>(conversion, PulseHas.Disabled);
            }

            /// <summary>
            /// When <see cref="Pulse"/> converted from <typeparamref name="TSignal"/> is <see cref="Pulse.HasEnabled"/>.
            /// </summary>
            /// <typeparam name="TSignal">
            /// Type of <see cref="ISignal"/> to detect.
            /// </typeparam>
            /// <param name="conversion">
            /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
            /// </param>
            /// <returns>
            /// <see cref="IDetection{TSignal}"/> to detect.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="conversion"/> is null.
            /// </exception>
            public static IDetection<TSignal> Enabled<TSignal>(IConversion<TSignal, Pulse> conversion)
                where TSignal : ISignal
            {
                if (conversion == null)
                {
                    throw new ArgumentNullException(nameof(conversion));
                }

                return new Detection<TSignal>(conversion, PulseHas.Enabled);
            }
        }

        private sealed class Detection<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly IConversion<TSignal, Pulse> conversion;

            private readonly IDetection<Pulse> detection;

            internal Detection(IConversion<TSignal, Pulse> conversion, IDetection<Pulse> detection)
            {
                this.conversion = conversion;

                this.detection = detection;
            }

            /// <inheritdoc/>
            public bool Detect(TSignal signal)
            {
                var pulse = conversion.Convert(signal);

                return detection.Detect(pulse);
            }
        }
    }
}
