using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConductionExtension
    {
        public static IEmission Connect<TSignal>(this ISource<TSignal> source, Action<TSignal> onReceived)
            where TSignal : ISignal
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return source.Connect(new InputTerminal<TSignal>(onReceived));
        }

        public static IDisconnection Connect<TSignal>(this IOutputTerminal<TSignal> terminal, IDivider<TSignal> divider)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (divider == null)
            {
                throw new ArgumentNullException(nameof(divider));
            }

            return divider.Connect(terminal);
        }
    }
}
