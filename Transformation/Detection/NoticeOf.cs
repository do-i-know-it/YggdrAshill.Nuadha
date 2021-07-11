using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    public sealed class NoticeOf
    {
        public static IDetection<TSignal> All<TSignal>()
            where TSignal : ISignal
        {
            return new Detection<TSignal>(true);
        }

        public static IDetection<TSignal> None<TSignal>()
            where TSignal : ISignal
        {
            return new Detection<TSignal>(false);
        }

        private sealed class Detection<TSignal> :
            IDetection<TSignal>
            where TSignal : ISignal
        {
            private readonly bool result;

            internal Detection(bool result)
            {
                this.result = result;
            }

            /// <inheritdoc/>
            public bool Detect(TSignal signal)
            {
                return result;
            }
        }
    }
}
