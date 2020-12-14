using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha
{
    public sealed class PullEventModule :
        IPullEventInputHandler,
        IPullEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Pulse> hasPulled = new Connector<Pulse>();
        
        private readonly Connector<Pulse> isPulled = new Connector<Pulse>();

        private readonly Connector<Pulse> hasReleased = new Connector<Pulse>();

        private readonly Connector<Pulse> isReleased = new Connector<Pulse>();

        #region IPullEventInputHandler

        IInputTerminal<Pulse> IPullEventInputHandler.HasPulled => hasPulled;

        IInputTerminal<Pulse> IPullEventInputHandler.IsPulled => isPulled;

        IInputTerminal<Pulse> IPullEventInputHandler.HasReleased => hasReleased;

        IInputTerminal<Pulse> IPullEventInputHandler.IsReleased => isReleased;

        #endregion

        #region IPullEventOutputHandler

        IOutputTerminal<Pulse> IPullEventOutputHandler.HasPulled => hasPulled;

        IOutputTerminal<Pulse> IPullEventOutputHandler.IsPulled => isPulled;
        
        IOutputTerminal<Pulse> IPullEventOutputHandler.HasReleased => hasReleased;
        
        IOutputTerminal<Pulse> IPullEventOutputHandler.IsReleased => isReleased;

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
