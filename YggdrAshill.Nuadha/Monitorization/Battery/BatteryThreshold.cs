using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Monitorization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class BatteryThreshold :
        ITarget<Battery>
    {
        private readonly IHysteresis hysteresis;

        private readonly Battery lower;

        private readonly Battery upper;

        public BatteryThreshold(IHysteresis hysteresis, Battery lower, Battery upper)
        {
            if (hysteresis == null)
            {
                throw new ArgumentNullException(nameof(hysteresis));
            }
            if (upper < lower)
            {
                throw new ArgumentException($"{nameof(lower)} is larger than {nameof(upper)}");
            }

            this.hysteresis = hysteresis;

            this.lower = lower;

            this.upper = upper;
        }

        public Battery Signal => hysteresis.IsExcited ? upper : lower;
    }
}
