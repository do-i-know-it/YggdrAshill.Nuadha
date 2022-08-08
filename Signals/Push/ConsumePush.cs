using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConsumption{TSignal}"/> for <see cref="Push"/>.
    /// </summary>
    public static class ConsumePush
    {
        /// <summary>
        /// Receives <see cref="Push"/> to consume like <paramref name="consumption"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <see cref="Push"/> as <see cref="bool"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<Push> Like(Action<bool> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return Consume<Push>.Like(signal =>
            {
                consumption.Invoke((bool)signal);
            });
        }
    }
}
