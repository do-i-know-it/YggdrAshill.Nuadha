using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Generator<TSignal> :
        IGenerator<TSignal>
        where TSignal : ISignal
    {
        private readonly Connector<TSignal> connector;

        private readonly Emission emission;
        
        #region Constructor

        public Generator(Func<TSignal> onEmitted)
        {
            if (onEmitted == null)
            {
                throw new ArgumentNullException(nameof(onEmitted));
            }
            
            connector = new Connector<TSignal>();

            emission = new Emission(() =>
            {
                var emitted = onEmitted.Invoke();

                connector.Receive(emitted);
            });
        }

        public Generator()
        {
            connector = new Connector<TSignal>();

            emission = new Emission();
        }

        #endregion

        #region IOutputTerminal

        public IDisconnection Connect(IInputTerminal<TSignal> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return connector.Connect(terminal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();
        }

        #endregion

        #region IIgnition

        public IEmission Ignite()
        {
            return emission;
        }

        #endregion
    }
}
