using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Generator<TSignal> :
        IGenerator<TSignal>
        where TSignal : ISignal
    {
        private readonly ISource<TSignal> source;

        private readonly IConnector<TSignal> connector;

        public Generator(ISource<TSignal> source, IConnector<TSignal> connector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (connector == null)
            {
                throw new ArgumentNullException(nameof(connector));
            }

            this.source = source;

            this.connector = connector;
        }

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

        #region IIgnitor

        public IEmission Ignite()
        {
            return source.Connect(connector);
        }

        #endregion
    }
}
