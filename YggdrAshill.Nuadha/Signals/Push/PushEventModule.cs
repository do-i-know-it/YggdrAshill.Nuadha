using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class PushEventModule :
        IPushEventInputHandler,
        IPushEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Pulse> hasPushed = new Connector<Pulse>();

        private readonly Connector<Pulse> isPushed = new Connector<Pulse>();

        private readonly Connector<Pulse> hasReleased = new Connector<Pulse>();

        private readonly Connector<Pulse> isReleased = new Connector<Pulse>();

        #region IPushEventInputHandler

        IInputTerminal<Pulse> IPushEventInputHandler.HasPushed => hasPushed;

        IInputTerminal<Pulse> IPushEventInputHandler.IsPushed => isPushed;

        IInputTerminal<Pulse> IPushEventInputHandler.HasReleased => hasReleased;

        IInputTerminal<Pulse> IPushEventInputHandler.IsReleased => isReleased;

        #endregion

        #region IPushEventOutputHandler

        IOutputTerminal<Pulse> IPushEventOutputHandler.HasPushed => hasPushed;

        IOutputTerminal<Pulse> IPushEventOutputHandler.IsPushed => isPushed;

        IOutputTerminal<Pulse> IPushEventOutputHandler.HasReleased => hasReleased;

        IOutputTerminal<Pulse> IPushEventOutputHandler.IsReleased => isReleased;

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
