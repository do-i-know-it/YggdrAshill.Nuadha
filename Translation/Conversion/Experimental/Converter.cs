using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Translation.Experimental
{
    internal sealed class Converter<TInput, TOutput> :
        IConnection<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConnection<TInput> connection;

        private readonly IConversion<TInput, TOutput> conversion;

        internal Converter(IConnection<TInput> connection, IConversion<TInput, TOutput> conversion)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            this.connection = connection;

            this.conversion = conversion;
        }

        public Conduction.IDisconnection Connect(IConsumption<TOutput> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return connection.Connect(new Convert(consumption, conversion));
        }

        private sealed class Convert :
            IConsumption<TInput>
        {
            private readonly IConsumption<TOutput> consumption;

            private readonly IConversion<TInput, TOutput> conversion;

            internal Convert(IConsumption<TOutput> consumption, IConversion<TInput, TOutput> conversion)
            {
                this.consumption = consumption;

                this.conversion = conversion;
            }

            public void Consume(TInput signal)
            {
                var converted = conversion.Convert(signal);

                consumption.Consume(converted);
            }
        }
    }
}
