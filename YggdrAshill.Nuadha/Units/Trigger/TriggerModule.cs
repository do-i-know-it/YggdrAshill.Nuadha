using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerModule :
        ITriggerDevice,
        ITriggerSystem,
        IDisconnection
    {
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Pull> pull = new Propagation<Pull>();

        #region ITriggerDevice

        IConnection<Touch> ITriggerDevice.Touch => touch;

        IConnection<Pull> ITriggerDevice.Pull => pull;

        #endregion

        #region ITriggerSystem

        IConsumption<Touch> ITriggerSystem.Touch => touch;

        IConsumption<Pull> ITriggerSystem.Pull => pull;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            pull.Disconnect();
        }

        #endregion
    }
}
