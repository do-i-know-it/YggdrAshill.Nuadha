using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickModule :
        IStickDevice,
        IStickSystem,
        IDisconnection
    {
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Tilt> tilt = new Propagation<Tilt>();

        #region IStickDevice

        IConnection<Touch> IStickDevice.Touch => touch;

        IConnection<Tilt> IStickDevice.Tilt => tilt;

        #endregion

        #region IStickSystem

        IConsumption<Touch> IStickSystem.Touch => touch;

        IConsumption<Tilt> IStickSystem.Tilt => tilt;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            tilt.Disconnect();
        }

        #endregion
    }
}
