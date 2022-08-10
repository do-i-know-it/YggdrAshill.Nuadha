using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Monitorization;

namespace YggdrAshill.Nuadha.Samples
{
    internal interface ISampleSoftware :
        ISoftware
    {
        IConsumption<Note> Input { get; }

        IProduction<Note> Output { get; }
    }
}
