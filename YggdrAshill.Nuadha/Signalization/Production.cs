using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Production<TSignal> :
        IProduction<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<IConsumption<TSignal>, IEmission> onProduced;

        #region Constructor

        public Production(Func<IConsumption<TSignal>, IEmission> onProduced)
        {
            if (onProduced == null)
            {
                throw new ArgumentNullException(nameof(onProduced));
            }

            this.onProduced = onProduced;
        }

        public Production()
        {
            onProduced = (_) =>
            {
                return new Emission();
            };
        }

        #endregion

        #region IProduction

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
