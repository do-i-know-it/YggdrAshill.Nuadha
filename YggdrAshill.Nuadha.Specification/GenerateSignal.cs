using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class GenerateSignal :
        IGeneration<Signal>
    {
        internal Signal Generated { get; } = new Signal();

        public Signal Generate()
        {
            return Generated;
        }
    }
}
