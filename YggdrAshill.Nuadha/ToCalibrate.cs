using System;
using YggdrAshill.Nuadha.Evaluation;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public static class ToCalibrate
    {
        public static IConversion<Accuracy<TSignal>, TSignal> Like<TSignal>(Func<Accuracy<TSignal>, TSignal> conversion)
            where TSignal : ISignal
        {
            return new Conversion<Accuracy<TSignal>, TSignal>(conversion);
        }
    }
}
