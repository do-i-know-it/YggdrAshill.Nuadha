using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerDevice :
        IHardware<IEyeTrackerHardwareHandler>,
        IDisconnection,
        IIgnition
    {
        private readonly IEyeTrackerConfiguration configuration;

        private readonly EyeTrackerModule module = new EyeTrackerModule();

        public EyeTrackerDevice(IEyeTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        private IEyeTrackerSoftwareHandler SoftwareHandler => module;

        public IDisconnection Connect(IEyeTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var pupil = SoftwareHandler.Pupil.Connect(handler.Pupil);

            var blink = SoftwareHandler.Blink.Connect(handler.Blink);

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
            module.Disconnect();
        }

        #endregion

        #region Ignition

        private IEyeTrackerHardwareHandler HardwareHandler => module;

        public IEmission Ignite()
        {
            var pupil = configuration.Pupil.Connect(HardwareHandler.Pupil);

            var blink = configuration.Blink.Connect(HardwareHandler.Blink);

            return new Emission(() =>
            {
                pupil.Emit();

                blink.Emit();

            });
        }

        #endregion
    }
}
