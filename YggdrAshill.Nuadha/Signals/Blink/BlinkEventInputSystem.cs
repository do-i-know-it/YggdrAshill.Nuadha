using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class BlinkEventInputSystem :
        IInputTerminal<Blink>,
        IBlinkEventOutputHandler,
        IDisconnection
    {
        private readonly IConnector<Blink> connector;

        private readonly IConnector<Pulse> hasOpened;

        private readonly IConnector<Pulse> isOpened;

        private readonly IConnector<Pulse> hasClosed;

        private readonly IConnector<Pulse> isClosed;

        public BlinkEventInputSystem(HysteresisThreshold threshold)
        {
            connector = new Connector<Blink>();

            hasOpened = new Connector<Pulse>();
            isOpened = new Connector<Pulse>();
            hasClosed = new Connector<Pulse>();
            isClosed = new Connector<Pulse>();

            connector.Convert(threshold).Pulsate(PushToPulse.HasPushed).Connect(hasOpened);
            connector.Convert(threshold).Pulsate(PushToPulse.IsPushed).Connect(isOpened);
            connector.Convert(threshold).Pulsate(PushToPulse.HasReleased).Connect(hasClosed);
            connector.Convert(threshold).Pulsate(PushToPulse.IsReleased).Connect(isClosed);
        }

        #region IBlinkEventOutputHandler

        public IOutputTerminal<Pulse> HasOpened => hasOpened;

        public IOutputTerminal<Pulse> IsOpened => isOpened;

        public IOutputTerminal<Pulse> HasClosed => hasClosed;

        public IOutputTerminal<Pulse> IsClosed => isClosed;

        #endregion

        #region IInputTerminal

        public void Receive(Blink signal)
        {
            connector.Receive(signal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();

            hasOpened.Disconnect();

            isOpened.Disconnect();

            hasClosed.Disconnect();

            isClosed.Disconnect();
        }

        #endregion
    }
}
