using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    internal sealed class Notate<TSignal> :
        ITranslation<TSignal, Note>
        where TSignal : ISignal
    {
        private readonly INotation<TSignal> notation;

        public Notate(INotation<TSignal> notation)
        {
            this.notation = notation;
        }

        public Note Translate(TSignal signal)
        {
            return notation.Notate(signal);
        }
    }
}
