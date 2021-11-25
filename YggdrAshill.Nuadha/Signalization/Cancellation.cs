using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ICancellation"/>.
    /// </summary>
    public sealed class Cancellation :
        ICancellation
    {
        /// <summary>
        /// Converts <see cref="Action"/> into <see cref="ICancellation"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="Action"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> converted from <see cref="Action"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        public static ICancellation Of(Action cancellation)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }

            return new Cancellation(cancellation);
        }

        /// <summary>
        /// <see cref="ICancellation"/> to do nothing.
        /// </summary>
        public static ICancellation None { get; } = Of(() => { });

        private readonly Action onCancelled;

        private Cancellation(Action onCancelled)
        {
            this.onCancelled = onCancelled;
        }

        /// <inheritdoc/>
        public void Cancel()
        {
            onCancelled.Invoke();
        }
    }
}
