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

            var terminal = new InputTerminal<TSignal>(signal =>
            {
                var corrected = correction.Correct(signal);

                inputTerminal.Receive(corrected);
            });

            return outputTerminal.Connect(terminal);
        }
    }
}
