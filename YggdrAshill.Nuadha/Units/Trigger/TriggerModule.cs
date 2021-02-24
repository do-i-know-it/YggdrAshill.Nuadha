using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerModule :
        ITriggerHardware,
        ITriggerSoftware,
        IDisconnection
    {
        private readonly Propagation<Touch> touch = new Propagation<Touch>();

        private readonly Propagation<Pull> pull = new Propagation<Pull>();

        #region ITriggerSoftware

        IConsumption<Touch> ITriggerSoftware.Touch => touch;

        IConsumption<Pull> ITriggerSoftware.Pull => pull;

        #endregion

        #region ITriggerHardware

        IConnection<Touch> ITriggerHardware.Touch => touch;

        IConnection<Pull> ITriggerHardware.Pull => pull;

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
