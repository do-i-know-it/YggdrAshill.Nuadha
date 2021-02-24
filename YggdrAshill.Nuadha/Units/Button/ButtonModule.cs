using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonModule :
        IButtonSoftware,
        IButtonHardware,
        IDisconnection
    {
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Push> push = new Propagation<Push>();

        #region IButtonSoftware

        IConsumption<Touch> IButtonSoftware.Touch => touch;

        IConsumption<Push> IButtonSoftware.Push => push;

        #endregion

        #region IButtonHardware

        IConnection<Touch> IButtonHardware.Touch => touch;

        IConnection<Push> IButtonHardware.Push => push;

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
