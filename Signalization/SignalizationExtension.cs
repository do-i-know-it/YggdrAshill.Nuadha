using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha.Signalization
{
    public static class SignalizationExtension
    {
        public static ICancellation Synthesize(this ICancellation cancellation, ICancellation to)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            var synthesized = new SynthesizedCancellation();

            synthesized.cancellations.Add(cancellation);
            synthesized.cancellations.Add(to);

            return synthesized;
        }

        private sealed class SynthesizedCancellation :
            ICancellation
        {
            internal readonly List<ICancellation> cancellations;

            internal SynthesizedCancellation()
            {
                cancellations = new List<ICancellation>();
            }

            public void Cancel()
            {
                foreach (var cancellation in cancellations)
                {
                    cancellation.Cancel();
                }

                cancellations.Clear();
            }
        }
    }
}
