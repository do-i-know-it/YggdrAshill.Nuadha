using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class BlinkEventInputSystem :
        IInputTerminal<Blink>,
        IPulseEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Blink> connector;

        private readonly PulseEventModule module;

        public BlinkEventInputSystem(HysteresisThreshold threshold)
        {
            connector = new Connector<Blink>();

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

        public void Receive(Blink signal)
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
