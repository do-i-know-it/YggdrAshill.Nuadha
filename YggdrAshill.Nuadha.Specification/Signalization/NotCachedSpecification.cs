using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(NotCached))]
    internal class NotCachedSpecification :
        IConsumption<Signal>
    {
        private NotCached.Propagation<Signal> propagation;
        private NotCached.Conduction<Signal> conduction;

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
            conduction = new NotCached.Conduction<Signal>(() =>
            {
                return expected;
            });

            propagation = new NotCached.Propagation<Signal>();
        }

        [TearDown]
        public void TearDown()
        {
            propagation.Dispose();

            conduction.Dispose();
        }

        [Test]
        public void PropagationShouldSendSignalToProducedWhenHasConsumed()
        {
            var cancellation = propagation.Produce(this);

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void PropagationShouldNotSendSignalToNotProducedWhenHasConsumed()
        {
            var cancellation = propagation.Produce(this);

            cancellation.Cancel();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumed);
        }

        [Test]
        public void PropagationShouldNotSendSignalAfterHasDisposed()
        {
            var cancellation = propagation.Produce(this);

            propagation.Dispose();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void PropagationCannotProduceNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = propagation.Produce(null);
            });
        }

        [Test]
        public void ConductionShouldSendSignalToProducedWhenHasEmitted()
        {
            var cancellation = conduction.Produce(this);

            conduction.Emit();

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ConductionShouldNotSendSignalToNotProducedWhenHasEmitted()
        {
            var cancellation = conduction.Produce(this);

            cancellation.Cancel();

            conduction.Emit();

            Assert.AreNotEqual(expected, consumed);
        }

        [Test]
        public void ConductionShouldNotSendSignalAfterHasDisposed()
        {
            var cancellation = conduction.Produce(this);

            conduction.Dispose();

            conduction.Emit();

            Assert.AreNotEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ConductionCannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conduction = new NotCached.Conduction<Signal>(null);
            });
        }

        [Test]
        public void ConductionCannotProduceNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = conduction.Produce(null);
            });
        }
    }
}
