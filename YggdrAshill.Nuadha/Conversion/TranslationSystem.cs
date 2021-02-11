using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TranslationSystem<TInput, TOutput> :
        IConnection<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConnection<TOutput> connection;

        public TranslationSystem(IConnection<TInput> connection, ITranslation<TInput, TOutput> translation)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            this.connection = connection.Translate(translation);
        }

        public IDisconnection Connect(IConsumption<TOutput> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return connection.Connect(consumption);
        }
    }
}
