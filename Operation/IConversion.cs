using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Operation
{
    public interface IConversion<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        TOutput Convert(TInput signal);
    }
}
