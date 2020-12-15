using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerEventInputSystem :
        ISoftware<IEyeTrackerSoftwareHandler>,
        IEyeTrackerEventOutputHandler,
        IDisconnection
    {
        private readonly PupilEventInputSystem pupil;

        private readonly BlinkEventInputSystem blink;

        public EyeTrackerEventInputSystem(IEyeTrackerThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            pupil = new PupilEventInputSystem(threshold.Pupil);

            blink = new BlinkEventInputSystem(threshold.Blink);
        }

        #region IEyeTrackerEventHandler

        public IPupilEventOutputHandler Pupil => pupil;

        public IBlinkEventOutputHandler Blink => blink;

        #endregion

        #region ISoftware

        public IDisconnection Connect(IEyeTrackerSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var pupil = handler.Pupil.Connect(this.pupil);

            var blink = handler.Blink.Connect(this.blink);

            return new Disconnection(() =>
            {
                pupil.Disconnect();

                blink.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            pupil.Disconnect();

            blink.Disconnect();
        }

        #endregion
    }
}
