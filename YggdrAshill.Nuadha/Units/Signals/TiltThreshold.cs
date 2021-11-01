using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Threshold to convert <see cref="Signals.Tilt"/> into <see cref="Transformation.Pulse"/>.
    /// </summary>
    public sealed class TiltThreshold
    {
        /// <summary>
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Distance"/>.
        /// </summary>
        public HysteresisThreshold Distance { get; }

        /// <summary>
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Left"/>.
        /// </summary>
        public HysteresisThreshold Left { get; }

        /// <summary>
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Right"/>.
        /// </summary>
        public HysteresisThreshold Right { get; }

        /// <summary>
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Upward"/>.
        /// </summary>
        public HysteresisThreshold Forward { get; }

        /// <summary>
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Downward"/>.
        /// </summary>
        public HysteresisThreshold Backward { get; }

        #region Constructor

        /// <summary>
        /// Constructs instance.
        /// </summary>
        /// <param name="distance">
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Distance"/>.
        /// </param>
        /// <param name="left">
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Left"/>.
        /// </param>
        /// <param name="right">
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Right"/>.
        /// </param>
        /// <param name="forward">
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Upward"/>.
        /// </param>
        /// <param name="backward">
        /// <see cref="HysteresisThreshold"/> for <see cref="Signals.Tilt.Downward"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="distance"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="left"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="right"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="forward"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="backward"/> is null.
        /// </exception>
        public TiltThreshold(
            HysteresisThreshold distance,
            HysteresisThreshold left, HysteresisThreshold right,
            HysteresisThreshold forward, HysteresisThreshold backward)
        {
            if (distance == null)
            {
                throw new ArgumentNullException(nameof(distance));
            }
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            if (forward == null)
            {
                throw new ArgumentNullException(nameof(forward));
            }
            if (backward == null)
            {
                throw new ArgumentNullException(nameof(backward));
            }

            Distance = distance;
            Left = left;
            Right = right;
            Forward = forward;
            Backward = backward;
        }

        /// <summary>
        /// Constructs instance.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> for all.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public TiltThreshold(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Distance = threshold;
            Left = threshold;
            Right = threshold;
            Forward = threshold;
            Backward = threshold;
        }

        #endregion
    }
}
