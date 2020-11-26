using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public static class SignalizationExtension
    {
        public static IDisconnection Connect<TSignal>(this IOutputTerminal<TSignal> terminal, Action<TSignal> onReceived)
            where TSignal : ISignal
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return terminal.Connect(new InputTerminal<TSignal>(onReceived));
        }

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
    }
}
