using System;
using YggdrAshill.Nuadha.Evaluation;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public static class ToFiltrate
    {
        public static IConversion<Sequence<TSignal>, TSignal> Like<TSignal>(Func<Sequence<TSignal>, TSignal> conversion)
            where TSignal : ISignal
        {
            return new Conversion<Sequence<TSignal>, TSignal>(conversion);
        }
    }
}
