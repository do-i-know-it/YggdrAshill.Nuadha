using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulseModule :
        IPulseDetectionInputHandler,
        IPulseDetectionOutputHandler,
        IDisconnection
    {
        private readonly Propagation<Pulse> hasEnabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> isEnabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> hasDisabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> isDisabled = new Propagation<Pulse>();

        #region IPulseDetectionInputHandler

        IConsumption<Pulse> IPulseDetectionInputHandler.HasEnabled => hasEnabled;

        IConsumption<Pulse> IPulseDetectionInputHandler.IsEnabled => isEnabled;

        IConsumption<Pulse> IPulseDetectionInputHandler.HasDisabled => hasDisabled;

        IConsumption<Pulse> IPulseDetectionInputHandler.IsDisabled => isDisabled;

        #endregion

        #region IPulseDetectionOutputHandler

        IConnection<Pulse> IPulseDetectionOutputHandler.HasEnabled => hasEnabled;

        IConnection<Pulse> IPulseDetectionOutputHandler.IsEnabled => isEnabled;

        IConnection<Pulse> IPulseDetectionOutputHandler.HasDisabled => hasDisabled;

        IConnection<Pulse> IPulseDetectionOutputHandler.IsDisabled => isDisabled;

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
