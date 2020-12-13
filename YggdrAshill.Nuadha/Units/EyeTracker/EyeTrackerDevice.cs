using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerDevice :
        IHardware<IEyeTrackerHardwareHandler>,
        IDisconnection,
        IIgnitor
    {
        private readonly IEyeTrackerConfiguration configuration;

        public EyeTrackerDevice(IEyeTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        public IDisconnection Connect(IEyeTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var pupil = configuration.Pupil.Connect(handler.Pupil);

            var blink = configuration.Blink.Connect(handler.Blink);

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
            configuration.Pupil.Disconnect();

            configuration.Blink.Disconnect();
        }

        #endregion

        #region Ignitor

        public IEmission Ignite()
        {
            var pupil = configuration.Pupil.Ignite();

            var blink = configuration.Blink.Ignite();

            return new Emission(() =>
            {
                pupil.Emit();

                blink.Emit();

            });
        }

        #endregion
    }
}
