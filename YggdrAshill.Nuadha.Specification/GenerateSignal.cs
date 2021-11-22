using YggdrAshill.Nuadha.Conduction;

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
