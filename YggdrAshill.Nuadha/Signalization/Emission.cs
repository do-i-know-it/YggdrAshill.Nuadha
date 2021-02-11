using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IEmission"/>.
    /// </summary>
    public sealed class Emission :
        IEmission
    {
        private readonly Action onEmitted;

        #region Constructor

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onEmitted">
        /// <see cref="Action"/> to execute when this has emitted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onEmitted"/> is null.
        /// </exception>
        public Emission(Action onEmitted)
        {
            if (onEmitted == null)
            {
                throw new ArgumentNullException(nameof(onEmitted));
            }

            this.onEmitted = onEmitted;
        }

        /// <summary>
        /// Constructs an instance to do nothing when this has emitted.
        /// </summary>
        public Emission()
        {
            onEmitted = () =>
            {

            };
        }

        #endregion

        #region IEmission

        /// <inheritdoc/>
        public void Emit()
        {
            onEmitted.Invoke();
        }

        #endregion
    }
}
