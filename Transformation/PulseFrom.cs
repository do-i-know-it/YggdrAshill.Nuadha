﻿using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    public static class PulseFrom
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pulse"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to be converted into <see cref="Pulse"/>.
        /// </typeparam>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IConversion<TSignal, Pulse> Signal<TSignal>(IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Conversion<TSignal>(detection);
        }
        private sealed class Conversion<TSignal> :
            IConversion<TSignal, Pulse>
            where TSignal : ISignal
        {
            private readonly IDetection<TSignal> detection;

            private Pulse previous = Pulse.IsDisabled;

            internal Conversion(IDetection<TSignal> detection)
            {
                this.detection = detection;
            }

            /// <inheritdoc/>
            public Pulse Convert(TSignal signal)
            {
                if (previous == Pulse.IsDisabled || previous == Pulse.HasDisabled)
                {
                    previous = detection.Detect(signal) ? Pulse.HasEnabled : Pulse.IsDisabled;
                }
                else if (previous == Pulse.IsEnabled || previous == Pulse.HasEnabled)
                {
                    previous = detection.Detect(signal) ? Pulse.IsEnabled : Pulse.HasDisabled;
                }

                return previous;
            }
        }
    }
}
