using YggdrAshill.Nuadha.Signalization;
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

        public StickDevice(IStickConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.configuration = configuration;
        }

        #region IHardware

        public IDisconnection Connect(IStickHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = configuration.Touch.Connect(handler.Touch);

            var push = configuration.Push.Connect(handler.Push);

            var tilt = configuration.Tilt.Connect(handler.Tilt);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                push.Disconnect();

                tilt.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            configuration.Touch.Disconnect();

            configuration.Push.Disconnect();

            configuration.Tilt.Disconnect();
        }

        #endregion

        #region Ignitor

        public IEmission Ignite()
        {
            var touch = configuration.Touch.Ignite();

            var push = configuration.Push.Ignite();

            var tilt = configuration.Tilt.Ignite();

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
