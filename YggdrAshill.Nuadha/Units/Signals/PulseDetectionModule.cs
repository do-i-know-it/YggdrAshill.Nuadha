using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulseDetectionModule :
        IDetectionHardwareHandler,
        IDetectionSoftwareHandler,
        IDisconnection
    {
        private readonly Propagation<Pulse> hasEnabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> isEnabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> hasDisabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> isDisabled = new Propagation<Pulse>();

        #region IPulseDetectionInputHandler

        IConsumption<Pulse> IDetectionHardwareHandler.HasEnabled => hasEnabled;

        IConsumption<Pulse> IDetectionHardwareHandler.IsEnabled => isEnabled;

        IConsumption<Pulse> IDetectionHardwareHandler.HasDisabled => hasDisabled;

        IConsumption<Pulse> IDetectionHardwareHandler.IsDisabled => isDisabled;

        #endregion

        #region IPulseDetectionOutputHandler

        IConnection<Pulse> IDetectionSoftwareHandler.HasEnabled => hasEnabled;

        IConnection<Pulse> IDetectionSoftwareHandler.IsEnabled => isEnabled;

        IConnection<Pulse> IDetectionSoftwareHandler.HasDisabled => hasDisabled;

        IConnection<Pulse> IDetectionSoftwareHandler.IsDisabled => isDisabled;

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
