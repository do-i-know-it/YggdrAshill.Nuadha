using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Translation
{
    public interface ICorrection<TSignal>
        where TSignal : ISignal
    {
        TSignal Correct(TSignal signal);
    }
}
