using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullThreshold :
        ITarget<Pull>
    {
        private readonly IHysteresis hysteresis;

        private readonly Pull lower;

        private readonly Pull upper;

        public PullThreshold(IHysteresis hysteresis, Pull lower, Pull upper)
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

        public Pull Signal => hysteresis.IsExcited ? lower : upper;
    }
}
