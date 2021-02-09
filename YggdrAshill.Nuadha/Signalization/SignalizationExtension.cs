using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public static class SignalizationExtension
    {
        public static IEmission Produce<TSignal>(this IProduction<TSignal> production, Action<TSignal> onConsumed)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (onConsumed == null)
            {
                throw new ArgumentNullException(nameof(onConsumed));
            }

            return production.Produce(new Consumption<TSignal>(onConsumed));
        }
    }
}
