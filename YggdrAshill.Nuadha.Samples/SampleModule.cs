using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Samples
{
    internal sealed class SampleModule :
        ISampleHardware,
        ISampleSoftware,
        IModule<ISampleHardware, ISampleSoftware>
    {
        private readonly IPropagation<Note> input = Propagate<Note>.WithList();

        private readonly IPropagation<Note> output = Propagate<Note>.WithList();

        public void Dispose()
        {
            input.Dispose();

            output.Dispose();
        }

        public ISampleHardware Hardware => this;

        public ISampleSoftware Software => this;

        IProduction<Note> ISampleHardware.Input => input;

        IConsumption<Note> ISampleSoftware.Input => input;

        IConsumption<Note> ISampleHardware.Output => output;

        IProduction<Note> ISampleSoftware.Output => output;
    }
}
