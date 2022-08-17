using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConsumption{TSignal}"/> for <see cref="Pull"/>.
    /// </summary>
    public static class ConsumePull
    {
        /// <summary>
        /// Receives <see cref="Pull"/> to consume like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <see cref="Pull"/> as <see cref="float"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<Pull> Like(Action<float> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return Consume<Pull>.Like(signal =>
            {
                consumption.Invoke((float)signal);
            });
        }
    }
}
