using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Conversion<TInput, TOutput> :
        IConversion<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly Func<TInput, TOutput> onConverted;

        public Conversion(Func<TInput, TOutput> onConverted)
        {
            if (onConverted == null)
            {
                throw new ArgumentNullException(nameof(onConverted));
            }

            this.onConverted = onConverted;
        }

        public TOutput Convert(TInput signal)
        {
            return onConverted.Invoke(signal);
        }
    }
}
