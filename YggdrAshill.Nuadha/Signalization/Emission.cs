using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IEmission"/>.
    /// </summary>
    public sealed class Emission :
        IEmission
    {
        /// <summary>
        /// Converts <see cref="Action"/> into <see cref="IEmission"/>.
        /// </summary>
        /// <param name="emission">
        /// <see cref="Action"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IEmission"/> converted from <see cref="Action"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="emission"/> is null.
        /// </exception>
        public static IEmission Of(Action emission)
        {
            if (emission == null)
            {
                throw new ArgumentNullException(nameof(emission));
            }

            return new Emission(emission);
        }

        /// <summary>
        /// <see cref="IEmission"/> to do nothing.
        /// </summary>
        public static IEmission None { get; } = Of(() => { });

        private readonly Action onEmitted;

        private Emission(Action onEmitted)
        {
            this.onEmitted = onEmitted;
        }

        /// <inheritdoc/>
        public void Emit()
        {
            onEmitted.Invoke();
        }
    }
}
