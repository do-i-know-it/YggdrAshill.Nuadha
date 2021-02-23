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
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Push> push = new Propagation<Push>();

        private readonly Propagation<Tilt> tilt = new Propagation<Tilt>();

        #region IStickSoftwareHandler

        IConnection<Touch> IButtonSoftwareHandler.Touch => touch;

        IConnection<Push> IButtonSoftwareHandler.Push => push;

        IConnection<Tilt> IStickSoftwareHandler.Tilt => tilt;

        #endregion

        #region IStickHardwareHandler

        IConsumption<Touch> IButtonHardwareHandler.Touch => touch;

        IConsumption<Push> IButtonHardwareHandler.Push => push;

        IConsumption<Tilt> IStickHardwareHandler.Tilt => tilt;

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
