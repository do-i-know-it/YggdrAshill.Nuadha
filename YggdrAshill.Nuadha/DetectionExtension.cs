using System;
using YggdrAshill.Nuadha.Evaluation;
using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

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
        public static IDetection<TSignal> Not<TSignal>(this IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            return new DetectInversed<TSignal>(detection);
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
        public static IDetection<TSignal> And<TSignal>(this IDetection<TSignal> first, IDetection<TSignal> second)
            where TSignal : ISignal
        {
            return new DetectBoth<TSignal>(first, second);
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
        public static IDetection<TSignal> And<TSignal>(this IDetection<TSignal> first, Func<TSignal, bool> second)
            where TSignal : ISignal
        {
            var detection = new Detection<TSignal>(second);
            return first.And(detection);
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
        public static IDetection<TSignal> Or<TSignal>(this IDetection<TSignal> first, IDetection<TSignal> second)
            where TSignal : ISignal
        {
            return new DetectEither<TSignal>(first, second);
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
            var detection = new Detection<TSignal>(second);
            return first.Or(detection);
        }

        public static IOutgoingFlow<TSignal> Switch<TSignal>(this IDetection<TSignal> detection, IOutgoingFlow<TSignal> then, IOutgoingFlow<TSignal> otherwise)
            where TSignal : ISignal
        {
            return new OutgoingToSwitch<TSignal>(detection, then, otherwise);
        }

        public static IOutgoingFlow<TSignal> Switch<TSignal>(this IDetection<TSignal> detection, Action<TSignal> then, Action<TSignal> otherwise)
            where TSignal : ISignal
        {
            var first = new OutgoingFlow<TSignal>(then);
            var second = new OutgoingFlow<TSignal>(otherwise);
            return detection.Switch(first, second);
        }

        public static IDetection<TInput> ToDetect<TInput, TOutput>(this IDetection<TOutput> detection, IConversion<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            return new DetectConverted<TInput,TOutput>(conversion, detection);
        }

        public static IDetection<TInput> ToDetect<TInput, TOutput>(this IDetection<TOutput> detection, Func<TInput, TOutput> onConverted)
            where TInput : ISignal
            where TOutput : ISignal
        {
            var conversion = new Conversion<TInput, TOutput>(onConverted);
            return detection.ToDetect(conversion);
        }

        public static IDetection<TSignal> ToCompare<TSignal>(this IDetection<Contrast<TSignal>> detection, IConversion<TSignal, Contrast<TSignal>> conversion)
            where TSignal : ISignal
        {
            return detection.ToDetect(conversion);
        }

        public static IDetection<TSignal> ToCompare<TSignal>(this IDetection<Contrast<TSignal>> detection, Func<TSignal, Contrast<TSignal>> conversion)
            where TSignal : ISignal
        {
            return detection.ToDetect(conversion);
        }
    }
}
