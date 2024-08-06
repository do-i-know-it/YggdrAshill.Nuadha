using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Disposable : IDisposable
    {
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
