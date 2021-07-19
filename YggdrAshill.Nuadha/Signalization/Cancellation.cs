using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="ICancellation"/>.
    /// </summary>
    public sealed class Cancellation :
        ICancellation
    {
        /// <summary>
        /// Executes <see cref="Action"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="Action"/> to cancel.
        /// </param>
        /// <returns>
        /// <see cref="Cancellation"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        public static Cancellation Of(Action cancellation)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }

            return new Cancellation(cancellation);
        }

        /// <summary>
        /// Executes none.
        /// </summary>
        public static Cancellation None { get; } = Of(() => { });

        private readonly Action onCancelled;

        private Cancellation(Action cancellation)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }

            this.onCancelled = cancellation;
        }

        /// <inheritdoc/>
        public void Cancel()
        {
            onCancelled.Invoke();
        }
    }
}
