using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDevice :
        IHardware<IStickHardwareHandler>,
        IDisconnection,
        IIgnitor
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

        private IStickSoftwareHandler SoftwareHandler => module;

        public IDisconnection Connect(IStickHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = SoftwareHandler.Touch.Connect(handler.Touch);

            var push = SoftwareHandler.Push.Connect(handler.Push);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                push.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            module.Disconnect();
        }

        #endregion

        #region Ignitor

        private IStickHardwareHandler HardwareHandler => module;

        public IEmission Ignite()
        {
            var touch = configuration.Touch.Connect(HardwareHandler.Touch);

            var push = configuration.Push.Connect(HardwareHandler.Push);

            var tilt = configuration.Tilt.Connect(HardwareHandler.Tilt);

            return new Emission(() =>
            {
                touch.Emit();

                push.Emit();

                tilt.Emit();

            });
        }

        #endregion
    }
}
