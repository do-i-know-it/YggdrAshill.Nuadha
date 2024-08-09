using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Samples;

internal sealed class Request : ISignal
{
    public string Content { get; set; }
}
