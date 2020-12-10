using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerEventSystem :
        ISoftware<IEyeTrackerSoftwareHandler>,
        IEyeTrackerEventHandler,
        IDisconnection
    {
        private readonly PupilEventSystem pupil;

        private readonly BlinkEventSystem blink;

        public EyeTrackerEventSystem(HysteresisThreshold pupil, HysteresisThreshold blink)
        {
            this.pupil = new PupilEventSystem(pupil);

            this.blink = new BlinkEventSystem(blink);
        }

        #region IEyeTrackerEventHandler

        public IPupilEventHandler Pupil => pupil;

        public IBlinkEventHandler Blink => blink;

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
