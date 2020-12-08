using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PushEventSystem :
        IPushEventSystem
    {
        private readonly IConnector<Pulse> hasPushed = new Connector<Pulse>();

        private readonly IConnector<Pulse> isPushed = new Connector<Pulse>();

        private readonly IConnector<Pulse> hasReleased = new Connector<Pulse>();

        private readonly IConnector<Pulse> isReleased = new Connector<Pulse>();

        #region IPushEventHandler

        public IOutputTerminal<Pulse> HasPushed => hasPushed;

        public IOutputTerminal<Pulse> IsPushed => isPushed;

        public IOutputTerminal<Pulse> HasReleased => hasReleased;

        public IOutputTerminal<Pulse> IsReleased => isReleased;

        #endregion

        #region IDivider

        public IDisconnection Connect(IOutputTerminal<Push> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            var hasPushed = terminal.Pulsate(PushToPulse.HasPushed).Connect(this.hasPushed);

            var isPushed = terminal.Pulsate(PushToPulse.IsPushed).Connect(this.isPushed);

            var hasReleased = terminal.Pulsate(PushToPulse.HasReleased).Connect(this.hasReleased);

            var isReleased = terminal.Pulsate(PushToPulse.IsReleased).Connect(this.isReleased);

            return new Disconnection(() =>
            {
                hasPushed.Disconnect();

                isPushed.Disconnect();

                hasReleased.Disconnect();

                isReleased.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            hasPushed.Disconnect();

            isPushed.Disconnect();

            hasReleased.Disconnect();

            isReleased.Disconnect();
        }

        #endregion
    }
}
