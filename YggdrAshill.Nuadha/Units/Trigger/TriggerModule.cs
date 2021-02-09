using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerModule :
        ITriggerSoftwareHandler,
        ITriggerHardwareHandler,
        IDisconnection
    {
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Pull> pull = new Propagation<Pull>();

        #region ITriggerSoftwareHandler

        IConnection<Touch> ITriggerSoftwareHandler.Touch => touch;

        IConnection<Pull> ITriggerSoftwareHandler.Pull => pull;

        #endregion

        #region ITriggerHardwareHandler
        
        IConsumption<Touch> ITriggerHardwareHandler.Touch => touch;

        IConsumption<Pull> ITriggerHardwareHandler.Pull => pull;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            pull.Disconnect();
        }

        #endregion
    }
}
