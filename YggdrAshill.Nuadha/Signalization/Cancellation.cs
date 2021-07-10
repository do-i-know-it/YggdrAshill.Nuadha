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
        private readonly Action onCancelled;

        #region Constructor

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

        /// <summary>
        /// Constructs an instance to do nothing when this has cancelled.
        /// </summary>
        public Cancellation()
        {
            onCancelled = () =>
            {

            };
        }

        #endregion

        #region ICancellation

        /// <inheritdoc/>
        public void Cancel()
        {
            onCancelled.Invoke();
        }

        #endregion
    }
}
