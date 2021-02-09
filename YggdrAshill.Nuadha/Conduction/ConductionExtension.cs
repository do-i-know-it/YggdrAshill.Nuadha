using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConductionExtension
    {
        public static IDisconnection Connect<TSignal>(this IConnection<TSignal> connection, Action<TSignal> onConsumed)
            where TSignal : ISignal
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (onConsumed == null)
            {
                throw new ArgumentNullException(nameof(onConsumed));
            }

            return connection.Connect(new Consumption<TSignal>(onConsumed));
        }
    }
}
