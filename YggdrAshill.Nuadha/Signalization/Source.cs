using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Source<TSignal> :
        ISource<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal> onEmitted;

        public Source(Func<TSignal> onEmitted)
        {
            if (onEmitted == null)
            {
                throw new ArgumentNullException(nameof(onEmitted));
            }

            this.onEmitted = onEmitted;
        }

        public IEmission Connect(IInputTerminal<TSignal> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return new Emission(() =>
            {
                var emitted = onEmitted.Invoke();

                terminal.Receive(emitted);
            });
        }
    }
}
