using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class InputTerminal<TSignal> :
        IInputTerminal<TSignal>
        where TSignal : ISignal
    {
        private readonly Action<TSignal> onReceived;

        #region Constructor

        public InputTerminal(Action<TSignal> onReceived)
        {
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            this.onReceived = onReceived;
        }

        public InputTerminal()
        {
            onReceived = (_) =>
            {

            };
        }

        #endregion

        #region IInputTerminal

        public void Receive(TSignal signal)
        {
            onReceived.Invoke(signal);
        }

        #endregion
    }
}
