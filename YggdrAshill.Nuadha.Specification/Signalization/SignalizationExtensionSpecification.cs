using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(SignalizationExtension))]
    internal class SignalizationExtensionSpecification
    {
        private Signal expected;

        private PropagateSignal propagation;

        private FakeCancellation cancellation;

        [SetUp]
        public void SetUp()
        {
            expected = new Signal();

            propagation = new PropagateSignal();

            cancellation = new FakeCancellation();
        }

        [Test]
        public void ShouldProduceSignal()
        {
            var consumed = default(Signal);
            var cancellation = propagation.Produce(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
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
        public void CannotProduceWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = default(IPropagation<Signal>).Produce(_ => { });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = propagation.Produce(default);
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
