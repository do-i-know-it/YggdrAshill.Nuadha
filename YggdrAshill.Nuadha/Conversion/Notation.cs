using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="INotation{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to notate.
    /// </typeparam>
    public sealed class Notation<TSignal> :
        INotation<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, Note> onNotated;

        #region Constructor

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onNotated">
        /// <see cref="Func{TSignal, Note}"/> to execute when this has notated.
        /// </param>
        public Notation(Func<TSignal, Note> onNotated)
        {
            if (onNotated == null)
            {
                throw new ArgumentNullException(nameof(onNotated));
            }

            this.onNotated = onNotated;
        }

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        public Notation()
        {
            onNotated = (_) =>
            {
                return new Note("");
            };
        }

        #endregion

        #region INotation

        /// <inheritdoc/>
        public Note Notate(TSignal signal)
        {
            return onNotated.Invoke(signal);
        }

        #endregion
    }
}
