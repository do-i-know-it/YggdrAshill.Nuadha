using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Threshold to convert HandController into PulsatedHandController.
    /// </summary>
    public sealed class HandControllerThreshold
    {
        /// <summary>
        /// <see cref="TiltThreshold"/> for <see cref="Thumb"/>.
        /// </summary>
        public TiltThreshold Thumb { get; }

        /// <summary>
        /// <see cref="TiltThreshold"/> for <see cref="IndexFinger"/>.
        /// </summary>
        public HysteresisThreshold IndexFinger { get; }

        /// <summary>
        /// <see cref="TiltThreshold"/> for <see cref="HandGrip"/>.
        /// </summary>
        public HysteresisThreshold HandGrip { get; }

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="thumb">
        /// <see cref="TiltThreshold"/> for <see cref="Thumb"/>.
        /// </param>
        /// <param name="indexFinger">
        /// <see cref="TiltThreshold"/> for <see cref="IndexFinger"/>.
        /// </param>
        /// <param name="handGrip">
        /// <see cref="TiltThreshold"/> for <see cref="HandGrip"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="thumb"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="indexFinger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="handGrip"/> is null.
        /// </exception>
        public HandControllerThreshold(TiltThreshold thumb, HysteresisThreshold indexFinger, HysteresisThreshold handGrip)
        {
            if (thumb == null)
            {
                throw new ArgumentNullException(nameof(thumb));
            }
            if (indexFinger == null)
            {
                throw new ArgumentNullException(nameof(indexFinger));
            }
            if (handGrip == null)
            {
                throw new ArgumentNullException(nameof(handGrip));
            }

            Thumb = thumb;

            IndexFinger = indexFinger;

            HandGrip = handGrip;
        }
    }
}
