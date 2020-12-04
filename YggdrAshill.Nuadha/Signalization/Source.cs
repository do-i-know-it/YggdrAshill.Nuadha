using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Source<TSignal> :
        ISource<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<IInputTerminal<TSignal>, IEmission> onConnected;

        #region Constructor

        public Source(Func<IInputTerminal<TSignal>, IEmission> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public Source(Func<TSignal> onEmitted)
        {
            if (onEmitted == null)
            {
                throw new ArgumentNullException(nameof(onEmitted));
            }

            onConnected = (terminal) =>
            {
                return new Emission(() =>
                {
                    var emitted = onEmitted.Invoke();

                    terminal.Receive(emitted);
                });
            };
        }

        public Source()
        {
            onConnected = (_) =>
            {
                return new Emission();
            };
        }

        #endregion

        #region ISource

        public IEmission Connect(IInputTerminal<TSignal> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return onConnected.Invoke(terminal);
        }

        #endregion
    }
}
