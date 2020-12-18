using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullEventSystem :
        IInputTerminal<Pull>,
        IDisconnection
    {
        private readonly Connector<Pull> connector;

        public PullEventSystem(HysteresisThreshold threshold, IPulseEventInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            connector = new Connector<Pull>();

            connector.Convert(threshold).Detect(PushToPulse.HasPushed()).Connect(handler.HasEnabled);
            connector.Convert(threshold).Detect(PushToPulse.IsPushed()).Connect(handler.IsEnabled);
            connector.Convert(threshold).Detect(PushToPulse.HasReleased()).Connect(handler.HasDisabled);
            connector.Convert(threshold).Detect(PushToPulse.IsReleased()).Connect(handler.IsDisabled);
        }

        public void Receive(Pull signal)
        {
            connector.Receive(signal);
        }

        public void Disconnect()
        {
            connector.Disconnect();
        }
    }
}
