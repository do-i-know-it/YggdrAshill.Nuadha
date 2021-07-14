using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
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
                    Propagation.WithoutCache.Create<Signal>(),
                    Propagation.WithLatestCache.Create(this),
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
            var propagation = Propagation.WithLatestCache.Create(this);

            var expected = new Signal();

            propagation.Consume(expected);

            var cancellation = propagation.Produce(this);

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotProduceNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = Propagation.WithoutCache.Create<Signal>().Produce(null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = Propagation.WithLatestCache.Create(this).Produce(null);
            });
        }

        [Test]
        public void WithLatestCacheCannotBeCreatedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var propagation = Propagation.WithLatestCache.Create<Signal>(null);
            });
        }
    }
}
