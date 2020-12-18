using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class CalibrationSystem<TSignal> :
        IInputTerminal<TSignal>,
        IDisconnection
        where TSignal : ISignal
    {
        private readonly Connector<TSignal> connector;

        public CalibrationSystem(IReduction<TSignal> reduction, ICalibration<TSignal> calibration, IInputTerminal<TSignal> terminal)
        {
            if (reduction == null)
            {
                throw new ArgumentNullException(nameof(reduction));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            connector = new Connector<TSignal>();

            connector.Calibrate(reduction, calibration).Connect(terminal);
        }

        #region IInputTerminal

        public void Receive(TSignal signal)
        {
            connector.Receive(signal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();
        }

        #endregion
    }
}
