using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Translation
{
    internal sealed class Detector<TSignal> :
        IOutputTerminal<Pulse>
        where TSignal : ISignal
    {
        private readonly IOutputTerminal<TSignal> terminal;

        private readonly IDetection<TSignal> detection;

        internal Detector(IOutputTerminal<TSignal> terminal, IDetection<TSignal> detection)
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

        public IDisconnection Connect(IInputTerminal<Pulse> terminal)
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
            private readonly IInputTerminal<Pulse> terminal;

            private readonly IDetection<TSignal> detection;

            internal Detect(IInputTerminal<Pulse> terminal, IDetection<TSignal> detection)
            {
                this.terminal = terminal;

                this.detection = detection;
            }

            public void Receive(TSignal signal)
            {
                if (!detection.Detect(signal))
                {
                    return;
                }

                terminal.Receive(Pulse.Instance);
            }
        }
    }
}
