using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Samples
{
    internal interface ISampleHardware : IHardware
    {
        IIncomingFlow<Note> Input { get; }

        IOutgoingFlow<Note> Output { get; }
    }
}
