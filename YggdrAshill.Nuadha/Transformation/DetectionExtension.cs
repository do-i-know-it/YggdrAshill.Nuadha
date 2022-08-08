using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IDetection{TSignal}"/> to operate <see cref="IDetection{TSignal}"/>.
    /// </summary>
    public static class DetectionExtension
    {
        /// <summary>
        /// When <typeparamref name="TSignal"/> is not satisfied by <paramref name="detection"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to invert.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> inverted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IDetection<TSignal> Not<TSignal>(this IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return That<TSignal>.IsNot(detection);
        }

        /// <summary>
        /// When <typeparamref name="TSignal"/> is satisfied by both <paramref name="first"/> and <paramref name="second"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="first">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to multiply.
        /// </param>
        /// <param name="second">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to multiply.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static IDetection<TSignal> And<TSignal>(this IDetection<TSignal> first, IDetection<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return That<TSignal>.IsBoth(first, second);
        }

        /// <summary>
        /// When <typeparamref name="TSignal"/> is satisfied by both <paramref name="first"/> and <paramref name="second"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="first">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to multiply.
        /// </param>
        /// <param name="second">
        /// <see cref="Func{T, TResult}"/> detecting <typeparamref name="TSignal"/> to multiply.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static IDetection<TSignal> And<TSignal>(this IDetection<TSignal> first, Func<TSignal, bool> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return first.And(That<TSignal>.Is(second));
        }

        /// <summary>
        /// When <typeparamref name="TSignal"/> is satisfied by either <paramref name="first"/> or <paramref name="second"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="first">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to add.
        /// </param>
        /// <param name="second">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to add.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static IDetection<TSignal> Or<TSignal>(this IDetection<TSignal> first, IDetection<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return That<TSignal>.IsEither(first, second);
        }

        /// <summary>
        /// When <typeparamref name="TSignal"/> is satisfied by either <paramref name="first"/> or <paramref name="second"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="first">
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> to add.
        /// </param>
        /// <param name="second">
        /// <see cref="Func{T, TResult}"/> detecting <typeparamref name="TSignal"/> to add.
        /// </param>
        /// <returns>
        /// <see cref="IDetection{TSignal}"/> for <typeparamref name="TSignal"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static IDetection<TSignal> Or<TSignal>(this IDetection<TSignal> first, Func<TSignal, bool> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return first.Or(That<TSignal>.Is(second));
        }

        public static IConsumption<TSignal> Switch<TSignal>(this IDetection<TSignal> detection, IConsumption<TSignal> then, IConsumption<TSignal> otherwise)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }
            if (then == null)
            {
                throw new ArgumentNullException(nameof(then));
            }
            if (otherwise == null)
            {
                throw new ArgumentNullException(nameof(otherwise));
            }

            return new ConsumeToSwitch<TSignal>(detection, then, otherwise);
        }

        public static IConsumption<TSignal> Switch<TSignal>(this IDetection<TSignal> detection, IConsumption<TSignal> then, Action<TSignal> otherwise)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }
            if (then == null)
            {
                throw new ArgumentNullException(nameof(then));
            }
            if (otherwise == null)
            {
                throw new ArgumentNullException(nameof(otherwise));
            }

            return detection.Switch(then, Consume<TSignal>.Like(otherwise));
        }

        public static IConsumption<TSignal> Switch<TSignal>(this IDetection<TSignal> detection, Action<TSignal> then, Action<TSignal> otherwise)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }
            if (then == null)
            {
                throw new ArgumentNullException(nameof(then));
            }
            if (otherwise == null)
            {
                throw new ArgumentNullException(nameof(otherwise));
            }

            return detection.Switch(Consume<TSignal>.Like(then), otherwise);
        }
    }
}
