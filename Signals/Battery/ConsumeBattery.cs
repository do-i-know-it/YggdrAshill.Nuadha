using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConsumption{TSignal}"/> for <see cref="Battery"/>.
    /// </summary>
    public static class ConsumeBattery
    {
        /// <summary>
        /// Receives <see cref="Battery"/> to consume like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <see cref="Battery"/> as <see cref="float"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Battery"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<Battery> Like(Action<float> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return Consume<Battery>.Like(signal =>
            {
                consumption.Invoke((float)signal);
            });
        }
    }
}
