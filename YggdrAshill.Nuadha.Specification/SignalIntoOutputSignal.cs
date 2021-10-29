using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class SignalIntoOutputSignal :
        ITranslation<Signal, OutputSignal>
    {
        internal OutputSignal Translated { get; } = new OutputSignal();

        public OutputSignal Translate(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Translated;
        }
    }
}
