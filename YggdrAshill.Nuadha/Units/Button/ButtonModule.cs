using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonModule :
        IButtonSoftwareHandler,
        IButtonHardwareHandler,
        IDisconnection
    {
        private readonly IConnector<Touch> touch = new Connector<Touch>();

        private readonly IConnector<Push> push = new Connector<Push>();

        #region IButtonSoftwareHandler

        IOutputTerminal<Touch> IButtonSoftwareHandler.Touch => touch;

        IOutputTerminal<Push> IButtonSoftwareHandler.Push => push;

        #endregion

        #region IButtonHardwareHandler

        IInputTerminal<Touch> IButtonHardwareHandler.Touch => touch;

        IInputTerminal<Push> IButtonHardwareHandler.Push => push;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            push.Disconnect();
        }

        #endregion
    }
}
