using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Corrector<TSignal> :
        IOutputTerminal<TSignal>
        where TSignal : ISignal
    {
        private readonly IOutputTerminal<TSignal> outputTerminal;

        private readonly ICorrection<TSignal> correction;

        public Corrector(
            IOutputTerminal<TSignal> outputTerminal,
            ICorrection<TSignal> correction)
        {
            if (outputTerminal == null)
            {
                throw new ArgumentNullException(nameof(outputTerminal));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            this.outputTerminal = outputTerminal;

            this.correction = correction;
        }

        public IDisconnection Connect(IInputTerminal<TSignal> inputTerminal)
        {
            if (inputTerminal == null)
            {
                throw new ArgumentNullException(nameof(inputTerminal));
            }

            var terminal = new InputTerminal(inputTerminal, correction);

            return outputTerminal.Connect(terminal);
        }

        private sealed class InputTerminal :
            IInputTerminal<TSignal>
        {
            private readonly IInputTerminal<TSignal> terminal;

            private readonly ICorrection<TSignal> correction;

            public InputTerminal(
                IInputTerminal<TSignal> terminal,
                ICorrection<TSignal> correction)
            {
                this.terminal = terminal;

                this.correction = correction;
            }

            public void Receive(TSignal signal)
            {
                var corrected = correction.Correct(signal);

                terminal.Receive(corrected);
            }
        }
    }
}
