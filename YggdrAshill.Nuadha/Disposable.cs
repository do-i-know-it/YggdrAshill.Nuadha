using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Disposable : IDisposable
    {
        public static Disposable None { get; } = new(() => { });

        private readonly Action onDisposed;

        public Disposable(Action onDisposed)
        {
            this.onDisposed = onDisposed;
        }

        public void Dispose()
        {
            onDisposed.Invoke();
        }
    }
}
