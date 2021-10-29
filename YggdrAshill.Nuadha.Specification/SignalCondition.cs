using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class SignalCondition :
        ICondition<Signal>
    {
        internal bool Previous { get; set; }

        public bool IsSatisfiedBy(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Previous;
        }
    }
}
