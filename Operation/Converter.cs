using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Converter<TInput, TOutput> :
        IOutputTerminal<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IOutputTerminal<TInput> outputTerminal;

        private readonly IConversion<TInput, TOutput> conversion;

        public Converter(
            IOutputTerminal<TInput> outputTerminal,
            IConversion<TInput, TOutput> conversion)
        {
            if (outputTerminal == null)
            {
                throw new ArgumentNullException(nameof(outputTerminal));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            this.outputTerminal = outputTerminal;

            this.conversion = conversion;
        }

        public IDisconnection Connect(IInputTerminal<TOutput> inputTerminal)
        {
            if (inputTerminal == null)
            {
                throw new ArgumentNullException(nameof(inputTerminal));
            }

            var terminal = new InputTerminal(inputTerminal, conversion);

            return outputTerminal.Connect(terminal);
        }

        private sealed class InputTerminal :
            IInputTerminal<TInput>
        {
            private readonly IInputTerminal<TOutput> terminal;

            private readonly IConversion<TInput, TOutput> conversion;

            public InputTerminal(
                IInputTerminal<TOutput> terminal,
                IConversion<TInput, TOutput> conversion)
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
