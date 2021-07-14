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
        /// <see cref="Cancellation"/> to do nothing when this has cancelled.
        /// </summary>
        public static Cancellation None { get; } = new Cancellation(() => { });

        private readonly Action onCancelled;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onCancelled">
        /// <see cref="Action"/> to execute when this has cancelled.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onCancelled"/> is null.
        /// </exception>
        public Cancellation(Action onCancelled)
        {
            if (onCancelled == null)
            {
                throw new ArgumentNullException(nameof(onCancelled));
            }

            this.onCancelled = onCancelled;
        }

        /// <inheritdoc/>
        public void Cancel()
        {
            onCancelled.Invoke();
        }
    }
}
