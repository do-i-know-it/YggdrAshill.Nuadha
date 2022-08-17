using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class FromInputSignalIntoMediumSignal :
        IConversion<InputSignal, MediumSignal>
    {
        internal MediumSignal Expected { get; } = new MediumSignal();

        public MediumSignal Convert(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Expected;
        }
    }
}
