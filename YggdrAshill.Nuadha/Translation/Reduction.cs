using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Reduction<TSignal> :
        IReduction<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, TSignal, TSignal> onReduced;

        public Reduction(Func<TSignal, TSignal, TSignal> onReduced)
        {
            if (onReduced == null)
            {
                throw new ArgumentNullException(nameof(onReduced));
            }

            this.onReduced = onReduced;
        }

        public TSignal Reduce(TSignal left, TSignal right)
        {
            return onReduced.Invoke(left, right);
        }
    }
}
