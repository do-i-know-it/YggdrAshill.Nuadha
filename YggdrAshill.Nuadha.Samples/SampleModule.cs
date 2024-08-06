using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Samples
{
    internal sealed class SampleModule :
        ISampleHardware,
        ISampleSoftware,
        IModule<ISampleHardware, ISampleSoftware>
    {
        private readonly IFlow<Note> input = new Flow<Note>();
        private readonly IFlow<Note> output = new Flow<Note>();

        public void Dispose()
        {
            input.Dispose();
            output.Dispose();
        }

        public ISampleHardware Hardware => this;

        public ISampleSoftware Software => this;

        IIncomingFlow<Note> ISampleHardware.Input => input;

        IOutgoingFlow<Note> ISampleSoftware.Input => input;

        IOutgoingFlow<Note> ISampleHardware.Output => output;

        IIncomingFlow<Note> ISampleSoftware.Output => output;
    }
}
