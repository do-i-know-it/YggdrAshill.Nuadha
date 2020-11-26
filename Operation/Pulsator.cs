using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Pulsator<TSignal> :
        IOutputTerminal<Pulse>
        where TSignal : ISignal
    {
        private readonly IOutputTerminal<TSignal> outputTerminal;

        private readonly IPulsation<TSignal> pulsation;

        private readonly TSignal initial;

        public Pulsator(
            IOutputTerminal<TSignal> outputTerminal,
            IPulsation<TSignal> pulsation,
            TSignal initial)
        {
            if (outputTerminal == null)
            {
                throw new ArgumentNullException(nameof(outputTerminal));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            this.outputTerminal = outputTerminal;

            this.pulsation = pulsation;

            this.initial = initial;
        }

        public IDisconnection Connect(IInputTerminal<Pulse> inputTerminal)
        {
            if (inputTerminal == null)
            {
                throw new ArgumentNullException(nameof(inputTerminal));
            }

            return outputTerminal.Connect(new Pulsate(inputTerminal, pulsation, initial));
        }

        private sealed class Pulsate :
            IInputTerminal<TSignal>
        {
            private readonly IInputTerminal<Pulse> inputTerminal;
            private readonly IPulsation<TSignal> pulsation;
            private TSignal previous;

            public Pulsate(
                IInputTerminal<Pulse> inputTerminal,
                IPulsation<TSignal> pulsation,
                TSignal previous)
            {
                this.inputTerminal = inputTerminal;

                this.pulsation = pulsation;

                this.previous = previous;
            }

            public void Receive(TSignal signal)
            {
                var hasPulsed = pulsation.Pulsate(previous, signal);
                previous = signal;

                if (hasPulsed)
                {
                    inputTerminal.Receive(Pulse.Instance);
                }
            }
        }
    }
}
