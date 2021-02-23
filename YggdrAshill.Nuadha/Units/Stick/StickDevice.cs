using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDevice :
        IInputHardware<IStickSystem>
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

        private IStickDevice Device => module;
        public IDisconnection Connect(IStickSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var touch = Device.Touch.Connect(system.Touch);

            var tilt = Device.Tilt.Connect(system.Tilt);

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

        private IStickSystem System => module;
        public IEmission Ignite()
        {
            var touch = configuration.Touch.Produce(System.Touch);

            var tilt = configuration.Tilt.Produce(System.Tilt);

            return new Emission(() =>
            {
                touch.Emit();

                tilt.Emit();

            });
        }

        #endregion
    }
}
