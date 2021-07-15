using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations for <see cref="IDetection{TSignal}"/>.
    /// </summary>
    public sealed class NoticeOf
    {
        public static IDetection<TSignal> Signal<TSignal>(Func<TSignal, bool> detection)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Detection<TSignal>(detection);
        }
        private sealed class Detection<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal, bool> detection;

            internal Detection(Func<TSignal, bool> detection)
            {
                this.detection = detection;
            }

            /// <inheritdoc/>
            public bool Detect(TSignal signal)
            {
                return detection.Invoke(signal);
            }
        }

        public static IDetection<TSignal> All<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => true);
        }

        public static IDetection<TSignal> None<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => false);
        }
    }
}
