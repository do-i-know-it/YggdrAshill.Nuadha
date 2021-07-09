using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PropagationWithoutCache<>))]
    internal class PropagationWithoutCacheSpecification :
        IConsumption<Signal>
    {
        private PropagationWithoutCache<Signal> propagation;

        private Signal expected;
        private Signal consumed;

        public void Consume(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumed = signal;
        }

        [SetUp]
        public void SetUp()
        {
            consumed = default;

            expected = new Signal();

            propagation = new PropagationWithoutCache<Signal>();
        }

        [TearDown]
        public void TearDown()
        {
            propagation.Dispose();
        }

        [Test]
        public void ShouldSendSignalToProducedWhenHasConsumed()
        {
            var cancellation = propagation.Produce(this);

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldNotSendSignalToNotProducedWhenHasConsumed()
        {
            var cancellation = propagation.Produce(this);

            cancellation.Cancel();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumed);
        }

        [Test]
        public void ShouldNotSendSignalAfterHasDisposed()
        {
            var cancellation = propagation.Produce(this);

            propagation.Dispose();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotProduceNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = propagation.Produce(null);
            });
        }
    }
}
