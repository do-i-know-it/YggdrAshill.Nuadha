using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullEventSystem :
        IConnection<Pull>,
        IPullEventHandler,
        IDisconnection
    {
        private readonly IConnector<Pulse> hasPulled = new Connector<Pulse>();

        private readonly IConnector<Pulse> isPulled = new Connector<Pulse>();

        private readonly IConnector<Pulse> hasReleased = new Connector<Pulse>();

        private readonly IConnector<Pulse> isReleased = new Connector<Pulse>();

        private readonly HysteresisThreshold threshold;

        public PullEventSystem(HysteresisThreshold threshold)
        {
            this.threshold = threshold;
        }

        #region IPullEventHandler

        public IOutputTerminal<Pulse> HasPulled => hasPulled;

        public IOutputTerminal<Pulse> IsPulled => isPulled;

        public IOutputTerminal<Pulse> HasReleased => hasReleased;

        public IOutputTerminal<Pulse> IsReleased => isReleased;

        #endregion

        #region IConnection

        public IDisconnection Connect(IOutputTerminal<Pull> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            var hasPulled = terminal.Convert(threshold).Pulsate(PushToPulse.HasPushed).Connect(this.hasPulled);

            var isPulled = terminal.Convert(threshold).Pulsate(PushToPulse.IsPushed).Connect(this.isPulled);

            var hasReleased = terminal.Convert(threshold).Pulsate(PushToPulse.HasReleased).Connect(this.hasReleased);

            var isReleased = terminal.Convert(threshold).Pulsate(PushToPulse.IsReleased).Connect(this.isReleased);

            return new Disconnection(() =>
            {
                hasPulled.Disconnect();

                isPulled.Disconnect();

                hasReleased.Disconnect();

                isReleased.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            hasPulled.Disconnect();

            isPulled.Disconnect();

            hasReleased.Disconnect();

            isReleased.Disconnect();
        }

        #endregion
    }
}
