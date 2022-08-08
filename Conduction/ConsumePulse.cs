using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines implementations of <see cref="IConsumption{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class ConsumePulse
    {
        /// <summary>
        /// Receives <see cref="Pulse"/> to consume like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="Action"/> to consume <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Pulse"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<Pulse> Like(Action consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return Consume<Pulse>.Like(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumption.Invoke();
            });
        }

        /// <summary>
        /// Receives <see cref="Pulse"/> to do nothing.
        /// </summary>
        public static IConsumption<Pulse> None { get; } = Like(() => { });
    }
}
