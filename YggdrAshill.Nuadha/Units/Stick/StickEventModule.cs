using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickEventModule :
        IStickEventInputHandler,
        IStickEventOutputHandler,
        IDisconnection
    {
        private readonly TouchEventModule touch = new TouchEventModule();

        private readonly PushEventModule push = new PushEventModule();

        private readonly TiltEventModule tilt = new TiltEventModule();

        #region IStickEventInputHandler

        ITouchEventInputHandler IButtonEventInputHandler.Touch => touch;

        IPushEventInputHandler IButtonEventInputHandler.Push => push;

        ITiltEventInputHandler IStickEventInputHandler.Tilt => tilt;

        #endregion

        #region IStickEventOutputHandler

        ITouchEventOutputHandler IButtonEventOutputHandler.Touch => touch;

        IPushEventOutputHandler IButtonEventOutputHandler.Push => push;

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
