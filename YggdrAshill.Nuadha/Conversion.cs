using System;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public sealed class Conversion<TInput, TOutput> : IConversion<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly Func<TInput, TOutput> onConverted;

        public Conversion(Func<TInput, TOutput> onConverted)
        {
            this.onConverted = onConverted;
        }

        public TOutput Convert(TInput signal)
        {
            return onConverted.Invoke(signal);
        }
    }
}
