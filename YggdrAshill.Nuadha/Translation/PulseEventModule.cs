using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulseEventModule :
        IPulseEventInputHandler,
        IPulseEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Pulse> hasEnabled = new Connector<Pulse>();

        private readonly Connector<Pulse> isEnabled = new Connector<Pulse>();

        private readonly Connector<Pulse> hasDisabled = new Connector<Pulse>();

        private readonly Connector<Pulse> isDisabled = new Connector<Pulse>();

        #region IPulseEventInputHandler

        IInputTerminal<Pulse> IPulseEventInputHandler.HasEnabled => hasEnabled;

        IInputTerminal<Pulse> IPulseEventInputHandler.IsEnabled => isEnabled;

        IInputTerminal<Pulse> IPulseEventInputHandler.HasDisabled => hasDisabled;

        IInputTerminal<Pulse> IPulseEventInputHandler.IsDisabled => isDisabled;

        #endregion

        #region IPulseEventOutputHandler

        IOutputTerminal<Pulse> IPulseEventOutputHandler.HasEnabled => hasEnabled;

        IOutputTerminal<Pulse> IPulseEventOutputHandler.IsEnabled => isEnabled;

        IOutputTerminal<Pulse> IPulseEventOutputHandler.HasDisabled => hasDisabled;

        IOutputTerminal<Pulse> IPulseEventOutputHandler.IsDisabled => isDisabled;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            hasEnabled.Disconnect();

            isEnabled.Disconnect();

            hasDisabled.Disconnect();

            isDisabled.Disconnect();
        }

        #endregion
    }
}
