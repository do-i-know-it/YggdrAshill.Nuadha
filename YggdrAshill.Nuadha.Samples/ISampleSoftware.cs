using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Samples
{
    internal interface ISampleSoftware : ISoftware
    {
        IOutgoingFlow<Note> Input { get; }

        IIncomingFlow<Note> Output { get; }
    }
}
