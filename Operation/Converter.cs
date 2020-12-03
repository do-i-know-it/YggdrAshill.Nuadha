using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Converter<TInput, TOutput> :
        IOutputTerminal<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IOutputTerminal<TInput> terminal;

        private readonly IConversion<TInput, TOutput> conversion;

        public Converter(IOutputTerminal<TInput> terminal, IConversion<TInput, TOutput> conversion)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            this.terminal = terminal;

            this.conversion = conversion;
        }

        public IDisconnection Connect(IInputTerminal<TOutput> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return this.terminal.Connect(new Convert(terminal, conversion));
        }

        private sealed class Convert :
            IInputTerminal<TInput>
        {
            private readonly IInputTerminal<TOutput> terminal;

            private readonly IConversion<TInput, TOutput> conversion;

            public Convert(IInputTerminal<TOutput> terminal, IConversion<TInput, TOutput> conversion)
            {
                this.terminal = terminal;

                this.conversion = conversion;
            }

            public void Receive(TInput signal)
            {
                var converted = conversion.Convert(signal);

                terminal.Receive(converted);
            }
        }
    }
}
