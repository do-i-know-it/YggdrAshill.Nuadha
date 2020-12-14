﻿using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class PullEventInputSystem :
        IInputTerminal<Pull>,
        IPullEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Pull> connector;

        private readonly Connector<Pulse> hasPulled;

        private readonly Connector<Pulse> isPulled;

        private readonly Connector<Pulse> hasReleased;

        private readonly Connector<Pulse> isReleased;

        public PullEventInputSystem(HysteresisThreshold threshold)
        {
            connector = new Connector<Pull>();

            hasPulled = new Connector<Pulse>();
            isPulled = new Connector<Pulse>();
            hasReleased = new Connector<Pulse>();
            isReleased = new Connector<Pulse>();

            connector.Convert(threshold).Pulsate(PushToPulse.HasPushed).Connect(hasPulled);
            connector.Convert(threshold).Pulsate(PushToPulse.IsPushed).Connect(isPulled);
            connector.Convert(threshold).Pulsate(PushToPulse.HasReleased).Connect(hasReleased);
            connector.Convert(threshold).Pulsate(PushToPulse.IsReleased).Connect(isReleased);
        }

        #region IPullEventOutputHandler

        public IOutputTerminal<Pulse> HasPulled => hasPulled;

        public IOutputTerminal<Pulse> IsPulled => isPulled;

        public IOutputTerminal<Pulse> HasReleased => hasReleased;

        public IOutputTerminal<Pulse> IsReleased => isReleased;

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

            hasPulled.Disconnect();

            isPulled.Disconnect();

            hasReleased.Disconnect();

            isReleased.Disconnect();
        }

        #endregion
    }
}