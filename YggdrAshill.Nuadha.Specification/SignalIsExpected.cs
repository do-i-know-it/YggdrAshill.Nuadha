using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class SignalIsExpected :
        IDetection<Signal>
    {
        internal bool Expected { get; set; }

        public bool Detect(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Expected;
        }
    }
}
