using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines implementations of <see cref="ICancellation"/>.
    /// </summary>
    public static class Cancel
    {
        /// <summary>
        /// Cancels with <paramref name="cancellation"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="Action"/> to cancel.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        public static ICancellation With(Action cancellation)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }

            return new CancelWith(cancellation);
        }
        private sealed class CancelWith :
            ICancellation
        {
            private readonly Action onCancelled;

            public CancelWith(Action onCancelled)
            {
                this.onCancelled = onCancelled;
            }

            public void Cancel()
            {
                onCancelled.Invoke();
            }
        }

        /// <summary>
        /// Cancels none.
        /// </summary>
        public static ICancellation None { get; } = With(() => { });
    }
}
