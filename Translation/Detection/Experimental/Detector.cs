using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Translation.Experimental
{
    internal sealed class Detector<TSignal> :
        IConnection<Pulse>
        where TSignal : ISignal
    {
        private readonly IConnection<TSignal> connection;

        private readonly IDetection<TSignal> detection;

        internal Detector(IConnection<TSignal> connection, IDetection<TSignal> detection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            this.connection = connection;

            this.detection = detection;
        }

        public Conduction.IDisconnection Connect(IConsumption<Pulse> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return connection.Connect(new Detect(consumption, detection));
        }

        private sealed class Detect :
            IConsumption<TSignal>
        {
            private readonly IConsumption<Pulse> consumption;

            private readonly IDetection<TSignal> detection;

            internal Detect(IConsumption<Pulse> consumption, IDetection<TSignal> detection)
            {
                this.consumption = consumption;

                this.detection = detection;
            }

            public void Consume(TSignal signal)
            {
                if (!detection.Detect(signal))
                {
                    return;
                }

                consumption.Consume(Pulse.Instance);
            }
        }
    }
}
