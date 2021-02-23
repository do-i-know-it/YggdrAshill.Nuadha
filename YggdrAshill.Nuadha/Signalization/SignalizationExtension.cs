using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Extension for Signalization.
    /// </summary>
    public static class SignalizationExtension
    {
        /// <summary>
        /// Produces with <see cref="Action{TSignal}"/> instead of <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to send.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce.
        /// </param>
        /// <param name="onConsumed">
        /// <see cref="Action{TSignal}"/> to execute when this has consumed <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IEmission"/> to emit.
        /// </returns>
        public static IEmission Produce<TSignal>(this IProduction<TSignal> production, Action<TSignal> onConsumed)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (onConsumed == null)
            {
                throw new ArgumentNullException(nameof(onConsumed));
            }

            return production.Produce(new Consumption<TSignal>(onConsumed));
        }

        /// <summary>
        /// Connects with <see cref="Action{TSignal}"/> instead of <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to send.
        /// </typeparam>
        /// <param name="connection">
        /// <see cref="IConnection{TSignal}"/> to connect.
        /// </param>
        /// <param name="onConsumed">
        /// <see cref="Action{TSignal}"/> to execute when this has consumed <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisconnection"/> to disconnect.
        /// </returns>
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
