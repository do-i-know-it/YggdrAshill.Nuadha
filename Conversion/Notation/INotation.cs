using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    public interface INotation<TSignal>
        where TSignal : ISignal
    {
        Note Notate(TSignal signal);
    }
}
