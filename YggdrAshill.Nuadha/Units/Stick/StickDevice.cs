using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDevice :
        IInputDevice<IStickSoftware>
    {
        private readonly IStickConfiguration configuration;

        private readonly StickModule module = new StickModule();

        public StickDevice(IStickConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        private IStickHardware Hardware => module;
        public IDisconnection Connect(IStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var touch = Hardware.Touch.Connect(software.Touch);

            var tilt = Hardware.Tilt.Connect(software.Tilt);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                tilt.Disconnect();
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

        private IStickSoftware Software => module;
        public IEmission Ignite()
        {
            var touch = configuration.Touch.Produce(Software.Touch);

            var tilt = configuration.Tilt.Produce(Software.Tilt);

            return new Emission(() =>
            {
                touch.Emit();

                tilt.Emit();

            });
        }

        #endregion
    }
}
