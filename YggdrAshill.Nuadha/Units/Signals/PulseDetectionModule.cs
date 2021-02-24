using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulseDetectionModule :
        IDetectionSoftware,
        IDetectionHardware,
        IDisconnection
    {
        private readonly Propagation<Pulse> hasEnabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> isEnabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> hasDisabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> isDisabled = new Propagation<Pulse>();

        #region IDetectionSoftware

        IConsumption<Pulse> IDetectionSoftware.HasEnabled => hasEnabled;

        IConsumption<Pulse> IDetectionSoftware.IsEnabled => isEnabled;

        IConsumption<Pulse> IDetectionSoftware.HasDisabled => hasDisabled;

        IConsumption<Pulse> IDetectionSoftware.IsDisabled => isDisabled;

        #endregion

        #region IDetectionHardware

        IConnection<Pulse> IDetectionHardware.HasEnabled => hasEnabled;

        IConnection<Pulse> IDetectionHardware.IsEnabled => isEnabled;

        IConnection<Pulse> IDetectionHardware.HasDisabled => hasDisabled;

        IConnection<Pulse> IDetectionHardware.IsDisabled => isDisabled;

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
