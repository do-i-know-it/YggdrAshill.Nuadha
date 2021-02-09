using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public abstract class CalibrationSystem<TSignal> :
        IPropagation<TSignal>
        where TSignal : ISignal
    {
        protected abstract IPropagation<TSignal> Propagation { get; }

        protected abstract IReduction<TSignal> Reduction { get; }

        protected abstract ICalibration<TSignal> Calibration { get; }
        
        #region IConsumption

        public void Consume(TSignal signal)
        {
            Propagation.Consume(signal);
        }

        #endregion

        #region IConnection

        public Conduction.IDisconnection Connect(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return Propagation.Calibrate(Reduction, Calibration).Connect(consumption);
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
