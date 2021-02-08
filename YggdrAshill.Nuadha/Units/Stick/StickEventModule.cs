using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickEventModule :
        IStickEventInputHandler,
        IStickEventOutputHandler,
        IDisconnection
    {
        private readonly PulseEventModule touch = new PulseEventModule();

        private readonly PulseEventModule push = new PulseEventModule();

        private readonly TiltEventModule tilt = new TiltEventModule();

        #region IStickEventInputHandler

        IPulseEventInputHandler IButtonEventInputHandler.Touch => touch;

        IPulseEventInputHandler IButtonEventInputHandler.Push => push;

        ITiltEventInputHandler IStickEventInputHandler.Tilt => tilt;

        #endregion

        #region IStickEventOutputHandler

        IPulseEventOutputHandler IButtonEventOutputHandler.Touch => touch;

        IPulseEventOutputHandler IButtonEventOutputHandler.Push => push;

        ITiltEventOutputHandler IStickEventOutputHandler.Tilt => tilt;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            push.Disconnect();

            tilt.Disconnect();
        }

        #endregion
    }
}
