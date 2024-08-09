using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Samples;

internal sealed class Response : ISignal
{
    internal enum ResultType
    {
        Success,
        Error,
        HowToUse
    }

    public ResultType Result { get; set; }

    public string Content { get; set; }
}
