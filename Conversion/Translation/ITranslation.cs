using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    public interface ITranslation<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        TOutput Translate(TInput signal);
    }
}
