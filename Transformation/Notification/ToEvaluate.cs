using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to notify.
    /// </typeparam>
    public static class ToEvaluate<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// When <typeparamref name="TSignal"/> is evaluated.
        /// </summary>
        /// <param name="evaluation">
        /// <see cref="IEvaluation{TSignal}"/> for <typeparamref name="TSignal"/> to notify.
        /// </param>
        /// <param name="threshold">
        /// <see cref="IThreshold{TSignal}"/> for <typeparamref name="TSignal"/> to notify.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="evaluation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static INotification<TSignal> With(IEvaluation<TSignal> evaluation, IThreshold<TSignal> threshold)
        {
            if (evaluation == null)
            {
                throw new ArgumentNullException(nameof(evaluation));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new NotifyToEvaluate(threshold, evaluation);
        }
        private sealed class NotifyToEvaluate :
            INotification<TSignal>
        {
            private readonly IThreshold<TSignal> threshold;

            private readonly IEvaluation<TSignal> evaluation;

            internal NotifyToEvaluate(IThreshold<TSignal> threshold, IEvaluation<TSignal> evaluation)
            {
                this.threshold = threshold;

                this.evaluation = evaluation;
            }

            public  bool Notify(TSignal signal)
            {
                return evaluation.Evaluate(signal, threshold.Signal);
            }
        }
    }
}
