using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Conversion
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
            this.connection = connection;

            this.conversion = conversion;
        }

        public IDisconnection Connect(IConsumption<TOutput> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return connection.Connect(new Convert<TInput, TOutput>(consumption, conversion));
        }
    }
}
