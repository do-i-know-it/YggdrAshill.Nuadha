using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Detector<TSignal> :
        IOutputTerminal<TSignal>
        where TSignal : ISignal
    {
        private readonly IOutputTerminal<TSignal> outputTerminal;

        private readonly IDetection<TSignal> detection;

        public Detector(
            IOutputTerminal<TSignal> outputTerminal,
            IDetection<TSignal> detection)
        {
            if (outputTerminal == null)
            {
                throw new ArgumentNullException(nameof(outputTerminal));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            this.outputTerminal = outputTerminal;

            this.detection = detection;
        }

        public IDisconnection Connect(IInputTerminal<TSignal> inputTerminal)
        {
            if (inputTerminal == null)
            {
                throw new ArgumentNullException(nameof(inputTerminal));
            }

            var terminal = new InputTerminal(inputTerminal, detection);

            return outputTerminal.Connect(terminal);
        }

        private sealed class InputTerminal :
            IInputTerminal<TSignal>
        {
            private readonly IInputTerminal<TSignal> terminal;

            private readonly IDetection<TSignal> detection;

            public InputTerminal(
                IInputTerminal<TSignal> terminal,
                IDetection<TSignal> detection)
            {
                this.terminal = terminal;

                this.detection = detection;
            }

            public void Receive(TSignal signal)
            {
                var hasDetected = detection.Detect(signal);

                if (hasDetected)
                {
                    terminal.Receive(signal);
                }
            }
        }
    }
}
