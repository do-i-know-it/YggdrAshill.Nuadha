using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Experimental.Specification
{
    [TestFixture(TestOf = typeof(Propagation<>))]
    internal class PropagationSpecification
    {
        private Propagation<Signal> propagation;
        private Consumption<Signal> consumption;

        private Signal expected;
        private Signal consumed;

        [SetUp]
        public void SetUp()
        {
            propagation = new Propagation<Signal>();

            consumed = default;
            consumption = new Consumption<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });

            expected = new Signal();
        }

        [TearDown]
        public void TearDown()
        {
            propagation.Dispose();
        }

        [Test]
        public void ShouldSendSignalToProducedWhenHasConsumed()
        {
            var cancellation = propagation.Produce(consumption);

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldNotSendSignalToNotProducedWhenHasConsumed()
        {
            var cancellation = propagation.Produce(consumption);

            cancellation.Cancel();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumed);
        }

        [Test]
        public void ShouldNotSendSignalAfterHasDisposed()
        {
            var cancellation = propagation.Produce(consumption);

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
