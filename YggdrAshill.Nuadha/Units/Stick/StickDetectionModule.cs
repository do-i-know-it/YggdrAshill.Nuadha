using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDetectionModule :
        IStickDetectionSoftware,
        IStickDetectionHardware,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly TiltDetectionModule tilt = new TiltDetectionModule();

        #region IStickDetectionSoftware

        IDetectionSoftware IStickDetectionSoftware.Touch => touch;

        ITiltDetectionSoftware IStickDetectionSoftware.Tilt => tilt;

        #endregion

        #region IStickDetectionHardware

        IDetectionHardware IStickDetectionHardware.Touch => touch;

        ITiltDetectionHardware IStickDetectionHardware.Tilt => tilt;

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
