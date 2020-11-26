using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Detection<TSignal> :
        IDetection<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, bool> onDetected;

        public Detection(Func<TSignal, bool> onDetected)
        {
            if (onDetected == null)
            {
                throw new ArgumentNullException(nameof(onDetected));
            }

            this.onDetected = onDetected;
        }

        public bool Detect(TSignal signal)
        {
            return onDetected.Invoke(signal);
        }
    }
}
