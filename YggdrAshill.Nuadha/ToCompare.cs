using System;
using YggdrAshill.Nuadha.Evaluation;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public static class ToCompare
    {
        public static IDetection<Contrast<TSignal>> Like<TSignal>(Func<Contrast<TSignal>, bool> detection)
            where TSignal : ISignal
        {
            return new Detection<Contrast<TSignal>>(detection);
        }
    }
}
