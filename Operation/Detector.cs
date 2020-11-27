using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
{
    public sealed class Detector<TSignal> :
        IOutputTerminal<TSignal>
        where TSignal : ISignal
    {
        private readonly IOutputTerminal<TSignal> terminal;

        private readonly IDetection<TSignal> detection;

        public Detector(IOutputTerminal<TSignal> terminal, IDetection<TSignal> detection)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            this.terminal = terminal;

            this.detection = detection;
        }

        public IDisconnection Connect(IInputTerminal<TSignal> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return this.terminal.Connect(new Detect(terminal, detection));
        }

        private sealed class Detect :
            IInputTerminal<TSignal>
        {
            private readonly IInputTerminal<TSignal> terminal;

            private readonly IDetection<TSignal> detection;

            public Detect(IInputTerminal<TSignal> terminal, IDetection<TSignal> detection)
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
