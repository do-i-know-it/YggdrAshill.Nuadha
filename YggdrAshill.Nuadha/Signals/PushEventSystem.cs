using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PushEventSystem :
        IInputTerminal<Push>,
        IDisconnection
    {
        private readonly Connector<Push> connector;

        public PushEventSystem(IPulseEventInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            connector = new Connector<Push>();

            connector.Detect(PushToPulse.HasPushed()).Connect(handler.HasEnabled);
            connector.Detect(PushToPulse.IsPushed()).Connect(handler.IsEnabled);
            connector.Detect(PushToPulse.HasReleased()).Connect(handler.HasDisabled);
            connector.Detect(PushToPulse.IsReleased()).Connect(handler.IsDisabled);
        }

        public void Receive(Push signal)
        {
            connector.Receive(signal);
        }

        public void Disconnect()
        {
            connector.Disconnect();
        }
    }
}
