using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(CancellationExtension))]
    internal class CancellationExtensionSpecification
    {
        private FakeCancellation cancellation;

        [SetUp]
        public void SetUp()
        {
            cancellation = new FakeCancellation();
        }

        [Test]
        public void ShouldConvertCancellationIntoDisposable()
        {
            cancellation.ToDisposable().Dispose();

            Assert.IsTrue(cancellation.Cancelled);
        }

        [Test]
        public void ConvertedDisposableShouldDisposeOnlyOnce()
        {
            var disposable = cancellation.ToDisposable();

            disposable.Dispose();

            Assert.Throws<ObjectDisposedException>(() =>
            {
                disposable.Dispose();
            });
        }

        [Test]
        public void CannotConvertWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                default(ICancellation).ToDisposable();
            });
        }
    }
}
