using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Configuration<THandler> :
        IConfiguration<THandler>
        where THandler : IHandler
    {
        private readonly Func<THandler, IEmission> onConnected;

        #region Constructor

        public Configuration(Func<THandler, IEmission> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public Configuration()
        {
            onConnected = (_) =>
            {
                return new Emission();
            };
        }

        #endregion

        #region IConfiguration

        public IEmission Connect(THandler handler)
        {
            return onConnected.Invoke(handler);
        }

        #endregion
    }
}
