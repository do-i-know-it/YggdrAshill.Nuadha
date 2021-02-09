using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha
{
    public abstract class ConversionSystem<TInput, TOutput> :
        IConsumption<TInput>,
        IConnection<TOutput>,
        IDisconnection
        where TInput : ISignal
        where TOutput : ISignal
    {
        protected abstract IPropagation<TInput> Propagation { get; }

        protected abstract IConversion<TInput, TOutput> Conversion { get; }

        #region IConsumption

        public void Consume(TInput signal)
        {
            Propagation.Consume(signal);
        }

        #endregion

        #region IConnection

        public IDisconnection Connect(IConsumption<TOutput> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return Propagation.Convert(Conversion).Connect(consumption);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            Propagation.Disconnect();
        }

        #endregion
    }
}
