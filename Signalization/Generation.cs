using System;

namespace YggdrAshill.Nuadha.Signalization
{
    internal sealed class Generation<TSignal> :
        IGeneration<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal> onGenerated;

        internal Generation(Func<TSignal> onGenerated)
        {
            this.onGenerated = onGenerated;
        }

        /// <inheritdoc/>
        public TSignal Generate()
        {
            return onGenerated.Invoke();
        }
    }
}
