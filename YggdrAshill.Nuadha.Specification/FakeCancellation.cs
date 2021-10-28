using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class FakeCancellation :
        ICancellation
    {
        internal bool Cancelled { get; private set; } = false;

        public void Cancel()
        {
            Cancelled = true;
        }
    }
}
