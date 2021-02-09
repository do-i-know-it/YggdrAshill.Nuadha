using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    public interface ICorrection<TSignal>
        where TSignal : ISignal
    {
        TSignal Correct(TSignal signal);
    }
}
