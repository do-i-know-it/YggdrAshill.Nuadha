using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerModule :
        ITriggerSoftwareHandler,
        ITriggerHardwareHandler,
        IDisconnection
    {
        private readonly IConnector<Touch> touch = new Connector<Touch>();

        private readonly IConnector<Pull> pull = new Connector<Pull>();

        #region ITriggerSoftwareHandler

        IOutputTerminal<Touch> ITriggerSoftwareHandler.Touch => touch;

        IOutputTerminal<Pull> ITriggerSoftwareHandler.Pull => pull;

        #endregion

        #region ITriggerHardwareHandler
        
        IInputTerminal<Touch> ITriggerHardwareHandler.Touch => touch;

        IInputTerminal<Pull> ITriggerHardwareHandler.Pull => pull;

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
