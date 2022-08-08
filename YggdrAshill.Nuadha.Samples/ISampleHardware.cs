using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Samples
{
    internal interface ISampleHardware :
        IHardware
    {
        IProduction<Note> Input { get; }

        IConsumption<Note> Output { get; }
    }
}
