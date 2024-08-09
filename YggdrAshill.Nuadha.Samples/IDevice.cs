using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Samples;

internal interface IDevice
{
    IIncomingFlow<Request> Keyboard { get; }
    IOutgoingFlow<Response> Display { get; }
}
