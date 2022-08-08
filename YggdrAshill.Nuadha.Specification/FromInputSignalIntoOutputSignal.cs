using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class FromInputSignalIntoOutputSignal :
        IConversion<InputSignal, OutputSignal>
    {
        internal OutputSignal Expected { get; } = new OutputSignal();

        public OutputSignal Convert(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Expected;
        }
    }
}
