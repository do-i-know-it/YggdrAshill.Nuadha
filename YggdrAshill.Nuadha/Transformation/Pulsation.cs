using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IPulsation{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to pulsate.
    /// </typeparam>
    public sealed class Pulsation<TSignal> :
        IPulsation<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Always converts <typeparamref name="TSignal"/> to <see cref="Pulse.IsDisabled"/>.
        /// </summary>
        public static Pulsation<TSignal> IsDisabled { get; }
            = new Pulsation<TSignal>(_ =>
            {
                return Pulse.IsDisabled;
            });
        /// <summary>
        /// Always converts <typeparamref name="TSignal"/> to <see cref="Pulse.HasDisabled"/>.
        /// </summary>
        public static Pulsation<TSignal> HasDisabled { get; }
            = new Pulsation<TSignal>(_ =>
            {
                return Pulse.HasDisabled;
            });
        /// <summary>
        /// Always converts <typeparamref name="TSignal"/> to <see cref="Pulse.IsEnabled"/>.
        /// </summary>
        public static Pulsation<TSignal> IsEnabled { get; }
            = new Pulsation<TSignal>(_ =>
            {
                return Pulse.IsEnabled;
            });
        /// <summary>
        /// Always converts <typeparamref name="TSignal"/> to <see cref="Pulse.HasEnabled"/>.
        /// </summary>
        public static Pulsation<TSignal> HasEnabled { get; }
            = new Pulsation<TSignal>(_ =>
            {
                return Pulse.HasEnabled;
            });

        private readonly Func<TSignal, Pulse> onPulsated;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onPulsated">
        /// <see cref="Func{TSignal, Pulse}"/> to execute when this has pulsated.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onPulsated"/> is null.
        /// </exception>
        public Pulsation(Func<TSignal, Pulse> onPulsated)
        {
            if (onPulsated == null)
            {
                throw new ArgumentNullException(nameof(onPulsated));
            }

            this.onPulsated = onPulsated;
        }

        /// <inheritdoc/>
        public Pulse Pulsate(TSignal signal)
        {
            return onPulsated.Invoke(signal);
        }
    }
}
