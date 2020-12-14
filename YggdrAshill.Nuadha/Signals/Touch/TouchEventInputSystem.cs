using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchEventInputSystem :
        IInputTerminal<Touch>,
        ITouchEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Touch> connector;

        private readonly Connector<Pulse> hasTouched;

        private readonly Connector<Pulse> isTouched;
        
        private readonly Connector<Pulse> hasReleased;
        
        private readonly Connector<Pulse> isReleased;

        public TouchEventInputSystem()
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

        #region ITouchEventOutputHandler

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
