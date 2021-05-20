using YggdrAshill.Nuadha.Transformation.Experimental;
using System;

namespace YggdrAshill.Nuadha.Signals.Experimental
{
    public sealed class TiltToPulse :
        IPulsation<Tilt>
    {
        public static TiltToPulse Distance(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new TiltToPulse(TiltToPull.Distance, new PullToPulse(threshold));
        }

        public static TiltToPulse Upward(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new TiltToPulse(TiltToPull.Upward, new PullToPulse(threshold));
        }
        public static TiltToPulse Downward(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new TiltToPulse(TiltToPull.Downward, new PullToPulse(threshold));
        }
        public static TiltToPulse Right(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new TiltToPulse(TiltToPull.Right, new PullToPulse(threshold));
        }
        public static TiltToPulse Left(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new TiltToPulse(TiltToPull.Left, new PullToPulse(threshold));
        }
       
        private readonly TiltToPull conversion;

        private readonly PullToPulse pulsation;

        private TiltToPulse(TiltToPull conversion, PullToPulse pulsation)
        {
            this.conversion = conversion;

            this.pulsation = pulsation;
        }

        /// <inheritdoc/>
        public Pulse Pulsate(Tilt signal)
        {
            var pull = conversion.Convert(signal);

            return pulsation.Pulsate(pull);
        }
    }
}
