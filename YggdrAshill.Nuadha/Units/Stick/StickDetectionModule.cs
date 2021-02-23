using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDetectionModule :
        IStickDetectionSystem,
        IStickDetectionDevice,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly TiltDetectionModule tilt = new TiltDetectionModule();

        #region IStickDetectionSystem

        IDetectionSystem IStickDetectionSystem.Touch => touch;

        ITiltDetectionSystem IStickDetectionSystem.Tilt => tilt;

        #endregion

        #region IStickDetectionDevice

        IDetectionDevice IStickDetectionDevice.Touch => touch;

        ITiltDetectionDevice IStickDetectionDevice.Tilt => tilt;

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
