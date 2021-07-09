using YggdrAshill.Nuadha.Signalization;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    public sealed class SynthesizedCancellation :
        ICancellation
    {
        internal readonly List<ICancellation> cancellations;

        public SynthesizedCancellation()
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
