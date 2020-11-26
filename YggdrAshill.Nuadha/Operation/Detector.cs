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

            var terminal = new InputTerminal<TSignal>(signal =>
            {
                var hasDetected = detection.Detect(signal);

                if (hasDetected)
                {
                    inputTerminal.Receive(signal);
                }
            });

            return outputTerminal.Connect(terminal);
        }
    }
}
