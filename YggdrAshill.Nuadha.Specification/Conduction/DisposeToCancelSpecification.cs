using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(DisposeToCancel))]
    internal class DisposeToCancelSpecification :
        ICancellation
    {
        private bool cancelled;

        void ICancellation.Cancel()
        {
            cancelled = true;
        }

        [SetUp]
        public void SetUp()
        {
            cancelled = false;
        }

        [Test]
        public void ShouldConvertCancellationIntoDisposable()
        {
            var disposable = new DisposeToCancel(this);

            disposable.Dispose();

            Assert.IsTrue(cancelled);
        }

        [Test]
        public void CannotDisposeTwice()
        {
            var disposable = new DisposeToCancel(this);

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
                var disposable = new DisposeToCancel(default);
            });
        }
    }
}
