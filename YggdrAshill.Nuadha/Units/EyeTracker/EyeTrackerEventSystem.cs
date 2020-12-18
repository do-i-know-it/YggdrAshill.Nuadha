using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerEventSystem :
        ISoftware<IEyeTrackerSoftwareHandler>,
        IDisconnection
    {
        private readonly PupilEventSystem pupil;

        private readonly BlinkEventSystem blink;

        public EyeTrackerEventSystem(IEyeTrackerThreshold threshold, IEyeTrackerEventInputHandler handler)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            pupil = new PupilEventSystem(threshold.Pupil, handler.Pupil);

            blink = new BlinkEventSystem(threshold.Blink, handler.Blink);
        }

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
