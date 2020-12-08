using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HardwareConfiguration<THardwareHandler> :
        IHardwareConfiguration<THardwareHandler>
        where THardwareHandler : IHardwareHandler
    {
        private readonly Func<THardwareHandler, IEmission> onConnected;

        #region Constructor

        public HardwareConfiguration(Func<THardwareHandler, IEmission> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public HardwareConfiguration()
        {
            onConnected = (_) =>
            {
                return new Emission();
            };
        }

        #endregion

        #region IHardwareConfiguration

        public IEmission Connect(THardwareHandler handler)
        {
            return onConnected.Invoke(handler);
        }

        #endregion
    }
}
