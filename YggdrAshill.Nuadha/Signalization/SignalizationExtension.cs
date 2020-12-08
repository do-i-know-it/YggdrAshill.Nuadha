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
    }
}
