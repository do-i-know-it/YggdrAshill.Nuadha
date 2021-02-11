using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class CorrectionSystem<TSignal> :
        IConnection<TSignal>
        where TSignal : ISignal
    {
        private readonly IConnection<TSignal> connection;

        public CorrectionSystem(IConnection<TSignal> connection, ICalculation<TSignal> calculation, IGeneration<TSignal> generation)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            this.connection = connection.Correct(calculation, generation);
        }

        #region IConnection

        public IDisconnection Connect(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return connection.Connect(consumption);
        }

        #endregion
    }
}
