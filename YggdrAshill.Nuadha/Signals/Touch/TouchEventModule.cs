using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchEventModule :
        ITouchEventInputHandler,
        ITouchEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Pulse> hasTouched = new Connector<Pulse>();

        private readonly Connector<Pulse> isTouched = new Connector<Pulse>();

        private readonly Connector<Pulse> hasReleased = new Connector<Pulse>();

        private readonly Connector<Pulse> isReleased = new Connector<Pulse>();

        #region ITouchEventInputHandler

        IInputTerminal<Pulse> ITouchEventInputHandler.HasTouched => hasTouched;

        IInputTerminal<Pulse> ITouchEventInputHandler.IsTouched => isTouched;

        IInputTerminal<Pulse> ITouchEventInputHandler.HasReleased => hasReleased;

        IInputTerminal<Pulse> ITouchEventInputHandler.IsReleased => isReleased);

        #endregion

        #region ITouchEventOutputHandler

        IOutputTerminal<Pulse> ITouchEventOutputHandler.HasTouched => hasTouched;

        IOutputTerminal<Pulse> ITouchEventOutputHandler.IsTouched => isTouched;

        IOutputTerminal<Pulse> ITouchEventOutputHandler.HasReleased => hasReleased;

        IOutputTerminal<Pulse> ITouchEventOutputHandler.IsReleased => isReleased);

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
