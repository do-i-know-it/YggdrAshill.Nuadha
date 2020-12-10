using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchEventSystem :
        IInputTerminal<Touch>,
        ITouchEventHandler,
        IDisconnection
    {
        private readonly IConnector<Touch> connector;

        private readonly IConnector<Pulse> hasTouched;

        private readonly IConnector<Pulse> isTouched;
        
        private readonly IConnector<Pulse> hasReleased;
        
        private readonly IConnector<Pulse> isReleased;

        public TouchEventSystem()
        {
            connector = new Connector<Touch>();

            hasTouched = new Connector<Pulse>();
            isTouched = new Connector<Pulse>();
            hasReleased = new Connector<Pulse>();
            isReleased = new Connector<Pulse>();

            connector.Pulsate(TouchToPulse.HasTouched).Connect(hasTouched);
            connector.Pulsate(TouchToPulse.IsTouched).Connect(isTouched);
            connector.Pulsate(TouchToPulse.HasReleased).Connect(hasReleased);
            connector.Pulsate(TouchToPulse.IsReleased).Connect(isReleased);
        }

        #region ITouchEventHandler

        public IOutputTerminal<Pulse> HasTouched => hasTouched;

        public IOutputTerminal<Pulse> IsTouched => isTouched;

        public IOutputTerminal<Pulse> HasReleased => hasReleased;

        public IOutputTerminal<Pulse> IsReleased => isReleased;

        #endregion

        #region IInputTerminal

        public void Receive(Touch signal)
        {
            connector.Receive(signal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();

            hasTouched.Disconnect();

            isTouched.Disconnect();

            hasReleased.Disconnect();

            isReleased.Disconnect();
        }

        #endregion
    }
}
