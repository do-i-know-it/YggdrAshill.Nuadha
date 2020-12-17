using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchEventInputSystem :
        IInputTerminal<Touch>,
        IPulseEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Touch> connector;

        private readonly PulseEventModule module;

        public TouchEventInputSystem()
        {
            connector = new Connector<Touch>();

            module = new PulseEventModule();

            connector.Detect(TouchToPulse.HasTouched()).Connect(EventInputHandler.HasEnabled);
            connector.Detect(TouchToPulse.IsTouched()).Connect(EventInputHandler.IsEnabled);
            connector.Detect(TouchToPulse.HasReleased()).Connect(EventInputHandler.HasDisabled);
            connector.Detect(TouchToPulse.IsReleased()).Connect(EventInputHandler.IsDisabled);
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

        public void Receive(Touch signal)
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
