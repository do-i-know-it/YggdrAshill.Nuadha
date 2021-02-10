using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IProduction{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal"></typeparam>
    public sealed class Production<TSignal> :
        IProduction<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<IConsumption<TSignal>, IEmission> onProduced;

        #region Constructor

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onProduced">
        /// <see cref="Func{IConsumption{TSignal}, IEmission}"/> to execute when this has produced.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onProduced"/> is null.
        /// </exception>
        public Production(Func<IConsumption<TSignal>, IEmission> onProduced)
        {
            if (onProduced == null)
            {
                throw new ArgumentNullException(nameof(onProduced));
            }

            this.onProduced = onProduced;
        }

        /// <summary>
        /// Constructs an instance to do nothing when this has produced.
        /// </summary>
        public Production()
        {
            onProduced = (_) =>
            {
                return new Emission();
            };
        }

        #endregion

        #region IProduction

        /// <inheritdoc/>
        public IEmission Produce(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return onProduced.Invoke(consumption);
        }

        #endregion
    }
}
