using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Propagation))]
    internal class PropagationSpecification :
        IConsumption<Signal>,
        IGeneration<Signal>
    {
        private IPropagation<Signal>[] TestSuiteForPropagation
        {
            get
            {
                return new[]
                {
                    Propagation.WithoutCache.Of<Signal>(),
                    Propagation.WithLatestCache.Of(this),
                };
            }
        }

        private Signal consumed;

        private Signal generated;

        public void Consume(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumed = signal;
        }

        public Signal Generate()
        {
            return generated;
        }

        [SetUp]
        public void SetUp()
        {
            consumed = default;

            generated = new Signal();
        }

        [Test]
        public void ShouldSendSignalToProducedWhenHasConsumed()
        {
            foreach (var propagation in TestSuiteForPropagation)
            {
                var cancellation = propagation.Produce(this);

                var expected = new Signal();

                propagation.Consume(expected);

                Assert.AreEqual(expected, consumed);

                cancellation.Cancel();
            }
        }

        [Test]
        public void ShouldNotSendSignalToNotProducedWhenHasConsumed()
        {
            foreach (var propagation in TestSuiteForPropagation)
            {
                var cancellation = propagation.Produce(this);

                cancellation.Cancel();

                var expected = new Signal();

                propagation.Consume(expected);

                Assert.AreNotEqual(expected, consumed);
            }
        }

        [Test]
        public void ShouldNotSendSignalAfterHasDisposed()
        {
            foreach (var propagation in TestSuiteForPropagation)
            {
                var cancellation = propagation.Produce(this);

                propagation.Dispose();

                var expected = new Signal();

                propagation.Consume(expected);

                Assert.AreNotEqual(expected, consumed);

                cancellation.Cancel();
            }
        }

        [Test]
        public void ShouldSendCachedSignalToProducedWhenHasProduced()
        {
            var propagation = Propagation.WithLatestCache.Of(this);

            var expected = new Signal();

            propagation.Consume(expected);

            var cancellation = propagation.Produce(this);

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotProduceNull()
        {
            foreach (var propagation in TestSuiteForPropagation)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var cancellation = propagation.Produce(default);
                });
            }
        }

        [Test]
        public void CannotBeCreatedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var propagation = Propagation.WithLatestCache.Of(default(IGeneration<Signal>));
            });
        }
    }
}
