using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PupilEventSystem :
        IInputTerminal<Pupil>,
        IDisconnection
    {
        private readonly Connector<Pupil> connector;

        public PupilEventSystem(IHysteresisThreshold threshold, IPulseEventInputHandler handler)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            connector = new Connector<Pupil>();

            connector.Convert(threshold).Detect(PushToPulse.HasEnabled()).Connect(handler.HasEnabled);
            connector.Convert(threshold).Detect(PushToPulse.IsEnabled()).Connect(handler.IsEnabled);
            connector.Convert(threshold).Detect(PushToPulse.HasDisabled()).Connect(handler.HasDisabled);
            connector.Convert(threshold).Detect(PushToPulse.IsDisabled()).Connect(handler.IsDisabled);
        }

        public void Receive(Pupil signal)
        {
            connector.Receive(signal);
        }

        public void Disconnect()
        {
            connector.Disconnect();
        }
    }
}
