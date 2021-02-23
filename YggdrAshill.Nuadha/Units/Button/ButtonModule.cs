using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonModule :
        IButtonSystem,
        IButtonDevice,
        IDisconnection
    {
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Push> push = new Propagation<Push>();

        #region IButtonSystem

        IConsumption<Touch> IButtonSystem.Touch => touch;

        IConsumption<Push> IButtonSystem.Push => push;

        #endregion

        #region IButtonDevice

        IConnection<Touch> IButtonDevice.Touch => touch;

        IConnection<Push> IButtonDevice.Push => push;

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
