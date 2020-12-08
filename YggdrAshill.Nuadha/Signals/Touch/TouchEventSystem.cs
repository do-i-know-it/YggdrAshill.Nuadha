using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchEventSystem :
        IConnection<Touch>,
        ITouchEventHandler,
        IDisconnection
    {
        private readonly IConnector<Pulse> hasTouched = new Connector<Pulse>();

        private readonly IConnector<Pulse> isTouched = new Connector<Pulse>();
        
        private readonly IConnector<Pulse> hasReleased = new Connector<Pulse>();
        
        private readonly IConnector<Pulse> isReleased = new Connector<Pulse>();

        #region ITouchEventHandler

        public IOutputTerminal<Pulse> HasTouched => hasTouched;

        public IOutputTerminal<Pulse> IsTouched => isTouched;

        public IOutputTerminal<Pulse> HasReleased => hasReleased;

        public IOutputTerminal<Pulse> IsReleased => isReleased;

        #endregion

        #region IConnection

        public IDisconnection Connect(IOutputTerminal<Touch> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            var hasTouched = terminal.Pulsate(TouchToPulse.HasTouched).Connect(this.hasTouched);

            var isTouched = terminal.Pulsate(TouchToPulse.IsTouched).Connect(this.isTouched);
            
            var hasReleased = terminal.Pulsate(TouchToPulse.HasReleased).Connect(this.hasReleased);
            
            var isReleased = terminal.Pulsate(TouchToPulse.IsReleased).Connect(this.isReleased);

            return new Disconnection(() =>
            {
                hasTouched.Disconnect();
            
                isTouched.Disconnect();
                
                hasReleased.Disconnect();
                
                isReleased.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            hasTouched.Disconnect();

            isTouched.Disconnect();

            hasReleased.Disconnect();

            isReleased.Disconnect();
        }

        #endregion
    }
}
