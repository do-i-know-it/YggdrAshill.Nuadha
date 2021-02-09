using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Conversion
{
    internal sealed class Detector<TSignal> :
        IConnection<Pulse>
        where TSignal : ISignal
    {
        private readonly IConnection<TSignal> connection;

        private readonly IDetection<TSignal> detection;

        internal Detector(IConnection<TSignal> connection, IDetection<TSignal> detection)
        {
            this.connection = connection;

            this.detection = detection;
        }

        public IDisconnection Connect(IConsumption<Pulse> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return connection.Connect(new Detect<TSignal>(consumption, detection));
        }
    }
}
