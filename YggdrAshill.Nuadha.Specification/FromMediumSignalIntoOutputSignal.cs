using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class FromMediumSignalIntoOutputSignal :
        IConversion<MediumSignal, OutputSignal>
    {
        internal OutputSignal Expected { get; } = new OutputSignal();

        public OutputSignal Convert(MediumSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Expected;
        }
    }
}
