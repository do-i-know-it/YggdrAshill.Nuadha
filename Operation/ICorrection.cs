using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Operation
{
    public interface ICorrection<TSignal>
        where TSignal : ISignal
    {
        TSignal Correct(TSignal signal);
    }
}
