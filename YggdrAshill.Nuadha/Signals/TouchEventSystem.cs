using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchEventSystem :
        IInputTerminal<Touch>,
        IDisconnection
    {
        private readonly Connector<Touch> connector;

        public TouchEventSystem(IPulseEventInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            connector = new Connector<Touch>();

            connector.Detect(TouchToPulse.HasEnabled()).Connect(handler.HasEnabled);
            connector.Detect(TouchToPulse.IsEnabled()).Connect(handler.IsEnabled);
            connector.Detect(TouchToPulse.HasDisabled()).Connect(handler.HasDisabled);
            connector.Detect(TouchToPulse.IsDisabled()).Connect(handler.IsDisabled);
        }

        public void Receive(Touch signal)
        {
            connector.Receive(signal);
        }

        public void Disconnect()
        {
            connector.Disconnect();
        }
    }
}
