using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class PullEventInputSystem :
        IInputTerminal<Pull>,
        IPulseEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Pull> connector;

        private readonly PulseEventModule module;

        public PullEventInputSystem(HysteresisThreshold threshold)
        {
            connector = new Connector<Pull>();

            module = new PulseEventModule();

            connector.Convert(threshold).Detect(PushToPulse.HasPushed()).Connect(EventInputHandler.HasEnabled);
            connector.Convert(threshold).Detect(PushToPulse.IsPushed()).Connect(EventInputHandler.IsEnabled);
            connector.Convert(threshold).Detect(PushToPulse.HasReleased()).Connect(EventInputHandler.HasDisabled);
            connector.Convert(threshold).Detect(PushToPulse.IsReleased()).Connect(EventInputHandler.IsDisabled);
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

        public void Receive(Pull signal)
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
