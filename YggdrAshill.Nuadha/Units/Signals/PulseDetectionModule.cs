using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulseDetectionModule :
        IDetectionSystem,
        IDetectionDevice,
        IDisconnection
    {
        private readonly Propagation<Pulse> hasEnabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> isEnabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> hasDisabled = new Propagation<Pulse>();

        private readonly Propagation<Pulse> isDisabled = new Propagation<Pulse>();

        #region IDetectionSystem

        IConsumption<Pulse> IDetectionSystem.HasEnabled => hasEnabled;

        IConsumption<Pulse> IDetectionSystem.IsEnabled => isEnabled;

        IConsumption<Pulse> IDetectionSystem.HasDisabled => hasDisabled;

        IConsumption<Pulse> IDetectionSystem.IsDisabled => isDisabled;

        #endregion

        #region IDetectionDevice

        IConnection<Pulse> IDetectionDevice.HasEnabled => hasEnabled;

        IConnection<Pulse> IDetectionDevice.IsEnabled => isEnabled;

        IConnection<Pulse> IDetectionDevice.HasDisabled => hasDisabled;

        IConnection<Pulse> IDetectionDevice.IsDisabled => isDisabled;

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
