using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class PushEventInputSystem :
        IInputTerminal<Push>,
        IPushEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Push> connector;

        private readonly Connector<Pulse> hasPushed;

        private readonly Connector<Pulse> isPushed;

        private readonly Connector<Pulse> hasReleased;

        private readonly Connector<Pulse> isReleased;

        public PushEventInputSystem()
        {
            connector = new Connector<Push>();

            hasPushed = new Connector<Pulse>();
            isPushed = new Connector<Pulse>();
            hasReleased = new Connector<Pulse>();
            isReleased = new Connector<Pulse>();

            connector.Pulsate(PushToPulse.HasPushed).Connect(hasPushed);
            connector.Pulsate(PushToPulse.IsPushed).Connect(isPushed);
            connector.Pulsate(PushToPulse.HasReleased).Connect(hasReleased);
            connector.Pulsate(PushToPulse.IsReleased).Connect(isReleased);
        }

        #region IPushEventOutputHandler

        public IOutputTerminal<Pulse> HasPushed => hasPushed;

        public IOutputTerminal<Pulse> IsPushed => isPushed;

        public IOutputTerminal<Pulse> HasReleased => hasReleased;

        public IOutputTerminal<Pulse> IsReleased => isReleased;

        #endregion

        #region IInputTerminal

        public void Receive(Push signal)
        {
            connector.Receive(signal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();

            hasPushed.Disconnect();

            isPushed.Disconnect();

            hasReleased.Disconnect();

            isReleased.Disconnect();
        }

        #endregion
    }
}
