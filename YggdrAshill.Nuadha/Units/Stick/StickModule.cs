using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickModule :
        IStickSoftware,
        IStickHardware,
        IDisconnection
    {
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Tilt> tilt = new Propagation<Tilt>();

        #region IStickSoftware

        IConsumption<Touch> IStickSoftware.Touch => touch;

        IConsumption<Tilt> IStickSoftware.Tilt => tilt;

        #endregion

        #region IStickHardware

        IConnection<Touch> IStickHardware.Touch => touch;

        IConnection<Tilt> IStickHardware.Tilt => tilt;

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
