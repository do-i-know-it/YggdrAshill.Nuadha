using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class InputSignalIntoSignal :
        ITranslation<InputSignal, Signal>
    {
        internal Signal Translated { get; } = new Signal();

        public Signal Translate(InputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Translated;
        }
    }
}
