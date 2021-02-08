using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    public sealed class Propagation<TSignal> :
        IPropagation<TSignal>
        where TSignal : ISignal
    {
        private readonly List<IConsumption<TSignal>> consumptionList = new List<IConsumption<TSignal>>();

        #region IConnection

        public Conduction.IDisconnection Connect(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            if (!consumptionList.Contains(consumption))
            {
                consumptionList.Add(consumption);
            }

            return new Disconnection(() =>
            {
                if (consumptionList.Contains(consumption))
                {
                    consumptionList.Remove(consumption);
                }
            });
        }

        #endregion

        #region IConsumption

        public void Consume(TSignal signal)
        {
            foreach (var consumption in consumptionList)
            {
                consumption.Consume(signal);
            }
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            consumptionList.Clear();
        }

        #endregion
    }
}
