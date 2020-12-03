using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Corrector<TSignal> :
        IOutputTerminal<TSignal>
        where TSignal : ISignal
    {
        private readonly IOutputTerminal<TSignal> terminal;

        private readonly ICorrection<TSignal> correction;

        public Corrector(IOutputTerminal<TSignal> terminal, ICorrection<TSignal> correction)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            this.terminal = terminal;

            this.correction = correction;
        }

        public IDisconnection Connect(IInputTerminal<TSignal> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return this.terminal.Connect(new Correct(terminal, correction));
        }

        private sealed class Correct :
            IInputTerminal<TSignal>
        {
            private readonly IInputTerminal<TSignal> terminal;

            private readonly ICorrection<TSignal> correction;

            public Correct(IInputTerminal<TSignal> terminal, ICorrection<TSignal> correction)
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
