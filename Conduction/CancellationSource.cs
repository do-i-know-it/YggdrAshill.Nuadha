using YggdrAshill.Nuadha.Signalization;
using System;
using System.Linq;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Collects <see cref="ICancellation"/>s to build.
    /// </summary>
    public sealed class CancellationSource
    {
        /// <summary>
        /// Creates default state <see cref="CancellationSource"/>.
        /// </summary>
        public static CancellationSource Default => new CancellationSource(new ICancellation[0]);

        private readonly IEnumerable<ICancellation> candidates;

        private CancellationSource(IEnumerable<ICancellation> candidates)
        {
            this.candidates = candidates;
        }

        /// <summary>
        /// Adds <see cref="ICancellation"/> to <see cref="CancellationSource"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="ICancellation"/> to collect.
        /// </param>
        /// <returns>
        /// <see cref="CancellationSource"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        public CancellationSource Synthesize(ICancellation cancellation)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }

            if (candidates.Contains(cancellation))
            {
                return this;
            }

            return new CancellationSource(candidates.Append(cancellation));
        }

        /// <summary>
        /// Builds <see cref="ICancellation"/> to cancel collected <see cref="ICancellation"/>s.
        /// </summary>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel collected <see cref="ICancellation"/>s.
        /// </returns>
        public ICancellation Build()
        {
            return new Cancellation(candidates.ToArray());
        }
        private sealed class Cancellation :
            ICancellation
        {
            private readonly ICancellation[] cancellations;

            internal Cancellation(ICancellation[] cancellations)
            {
                this.cancellations = cancellations;
            }

            public void Cancel()
            {
                foreach (var cancellation in cancellations)
                {
                    cancellation.Cancel();
                }
            }
        }
    }
}
