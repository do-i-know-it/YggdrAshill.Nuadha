using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    public abstract class CorrectionSystem<TSignal> :
        IPropagation<TSignal>
        where TSignal : ISignal
    {
        protected abstract IPropagation<TSignal> Propagation { get; }

        protected abstract ICalculation<TSignal> Calculation { get; }

        protected abstract IGeneration<TSignal> Generation { get; }
        
        #region IConsumption

        public void Consume(TSignal signal)
        {
            Propagation.Consume(signal);
        }

        #endregion

        #region IConnection

        public IDisconnection Connect(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return Propagation.Connect(consumption.Correct(Calculation, Generation));
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
