using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Translation<TInput, TOutput> :
        ITranslation<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly Func<TInput, TOutput> onTranslated;

        public Translation(Func<TInput, TOutput> onTranslated)
        {
            if (onTranslated == null)
            {
                throw new ArgumentNullException(nameof(onTranslated));
            }

            this.onTranslated = onTranslated;
        }

        public TOutput Translate(TInput signal)
        {
            return onTranslated.Invoke(signal);
        }
    }
}
