using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Notation<TSignal> :
        INotation<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, Note> onNotated;

        public Notation(Func<TSignal, Note> onNotated)
        {
            if (onNotated == null)
            {
                throw new ArgumentNullException(nameof(onNotated));
            }

            this.onNotated = onNotated;
        }

        public Note Notate(TSignal signal)
        {
            return onNotated.Invoke(signal);
        }
    }
}
