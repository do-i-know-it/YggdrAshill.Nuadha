using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public sealed class Detection<TSignal> : IDetection<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, bool> onDetected;

        public Detection(Func<TSignal, bool> onDetected)
        {
            this.onDetected = onDetected;
        }

        public bool Detect(TSignal signal)
        {
            return onDetected.Invoke(signal);
        }
    }
}
