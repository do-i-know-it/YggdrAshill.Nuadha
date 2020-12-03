using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Pulsator<TSignal> :
        IOutputTerminal<Pulse>
        where TSignal : ISignal
    {
        private readonly IOutputTerminal<TSignal> terminal;

        private readonly IPulsation<TSignal> pulsation;

        private readonly TSignal initial;

        public Pulsator(IOutputTerminal<TSignal> terminal, IPulsation<TSignal> pulsation, TSignal initial)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            this.terminal = terminal;

            this.pulsation = pulsation;

            this.initial = initial;
        }

        public IDisconnection Connect(IInputTerminal<Pulse> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return this.terminal.Connect(new Pulsate(terminal, pulsation, initial));
        }

        private sealed class Pulsate :
            IInputTerminal<TSignal>
        {
            private readonly IInputTerminal<Pulse> terminal;

            private readonly IPulsation<TSignal> pulsation;

            private TSignal previous;

            public Pulsate(IInputTerminal<Pulse> terminal, IPulsation<TSignal> pulsation, TSignal previous)
            {
                this.terminal = terminal;

                this.pulsation = pulsation;

                this.previous = previous;
            }

            public void Receive(TSignal signal)
            {
                var hasPulsed = pulsation.Pulsate(previous, signal);
                previous = signal;

                if (hasPulsed)
                {
                    terminal.Receive(Pulse.Instance);
                }
            }
        }
    }
}
