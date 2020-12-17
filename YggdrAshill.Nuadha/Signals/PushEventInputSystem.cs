using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class PushEventInputSystem :
        IInputTerminal<Push>,
        IPulseEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Push> connector;

        private readonly PulseEventModule module;

        public PushEventInputSystem()
        {
            connector = new Connector<Push>();

            module = new PulseEventModule();

            connector.Detect(PushToPulse.HasPushed()).Connect(EventInputHandler.HasEnabled);
            connector.Detect(PushToPulse.IsPushed()).Connect(EventInputHandler.IsEnabled);
            connector.Detect(PushToPulse.HasReleased()).Connect(EventInputHandler.HasDisabled);
            connector.Detect(PushToPulse.IsReleased()).Connect(EventInputHandler.IsDisabled);
        }

        private IPulseEventOutputHandler EventOutputHandler => module;

        private IPulseEventInputHandler EventInputHandler => module;

        #region IPulseEventOutputHandler

        public IOutputTerminal<Pulse> HasEnabled => EventOutputHandler.HasEnabled;

        public IOutputTerminal<Pulse> IsEnabled => EventOutputHandler.IsEnabled;

        public IOutputTerminal<Pulse> HasDisabled => EventOutputHandler.HasDisabled;

        public IOutputTerminal<Pulse> IsDisabled => EventOutputHandler.IsDisabled;

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

            module.Disconnect();
        }

        #endregion
    }
}
