using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class InputSignal : ISignal
    {
        public OutputSignal OutputSignal { get; } = new();
        public MediumSignal MediumSignal { get; } = new();
    }
}
