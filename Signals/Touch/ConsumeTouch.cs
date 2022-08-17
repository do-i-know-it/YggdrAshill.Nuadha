using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConsumption{TSignal}"/> for <see cref="Touch"/>.
    /// </summary>
    public static class ConsumeTouch
    {
        /// <summary>
        /// Receives <see cref="Touch"/> to consume like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <see cref="Touch"/> as <see cref="bool"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<Touch> Like(Action<bool> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return Consume<Touch>.Like(signal =>
            {
                consumption.Invoke((bool)signal);
            });
        }
    }
}
