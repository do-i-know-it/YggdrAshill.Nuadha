using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickModule :
        IStickSoftwareHandler,
        IStickHardwareHandler,
        IDisconnection
    {
        private readonly IConnector<Touch> touch = new Connector<Touch>();

        private readonly IConnector<Push> push = new Connector<Push>();

        private readonly IConnector<Tilt> tilt = new Connector<Tilt>();

        #region IStickSoftwareHandler

        IOutputTerminal<Touch> IButtonSoftwareHandler.Touch => touch;

        IOutputTerminal<Push> IButtonSoftwareHandler.Push => push;

        IOutputTerminal<Tilt> IStickSoftwareHandler.Tilt => tilt;

        #endregion

        #region IStickHardwareHandler

        IInputTerminal<Touch> IButtonHardwareHandler.Touch => touch;

        IInputTerminal<Push> IButtonHardwareHandler.Push => push;

        IInputTerminal<Tilt> IStickHardwareHandler.Tilt => tilt;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            push.Disconnect();

            tilt.Disconnect();
        }

        #endregion
    }
}
