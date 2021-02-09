using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonModule :
        IButtonSoftwareHandler,
        IButtonHardwareHandler,
        IDisconnection
    {
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Push> push = new Propagation<Push>();

        #region IButtonSoftwareHandler

        IConnection<Touch> IButtonSoftwareHandler.Touch => touch;

        IConnection<Push> IButtonSoftwareHandler.Push => push;

        #endregion

        #region IButtonHardwareHandler

        IConsumption<Touch> IButtonHardwareHandler.Touch => touch;

        IConsumption<Push> IButtonHardwareHandler.Push => push;

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
