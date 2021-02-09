using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Conversion
{
    internal sealed class Translator<TInput, TOutput> :
        IConnection<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConnection<TInput> connection;

        private readonly ITranslation<TInput, TOutput> translation;

        internal Translator(IConnection<TInput> connection, ITranslation<TInput, TOutput> translation)
        {
            this.connection = connection;

            this.translation = translation;
        }

        public IDisconnection Connect(IConsumption<TOutput> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return connection.Connect(new Translate<TInput, TOutput>(consumption, translation));
        }
    }
}
