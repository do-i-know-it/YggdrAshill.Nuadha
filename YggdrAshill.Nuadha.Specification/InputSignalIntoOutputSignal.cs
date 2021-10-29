using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class InputSignalIntoOutputSignal :
        ITranslation<InputSignal, OutputSignal>
    {
        internal OutputSignal Translated { get; } = new OutputSignal();

        public OutputSignal Translate(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Translated;
        }
    }
}
