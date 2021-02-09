using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    internal sealed class Correct<TSignal> :
        ITranslation<TSignal, TSignal>
        where TSignal : ISignal
    {
        private readonly ICorrection<TSignal> correction;

        internal Correct(ICorrection<TSignal> correction)
        {
            this.correction = correction;
        }

        public TSignal Translate(TSignal signal)
        {
            return correction.Correct(signal);
        }
    }
}
