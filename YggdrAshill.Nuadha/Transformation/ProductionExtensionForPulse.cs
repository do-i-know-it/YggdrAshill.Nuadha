using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public static class ProductionExtensionForPulse
    {
        /// <summary>
        /// Sends <see cref="Pulse"/> to <see cref="Action"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to send <see cref="Pulse"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action"/> to receive <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Produce(this IProduction<Pulse> production, Action consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(ConsumePulse.Like(consumption));
        }
    }
}
