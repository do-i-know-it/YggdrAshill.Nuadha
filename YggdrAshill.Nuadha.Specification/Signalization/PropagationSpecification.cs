using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Propagation))]
    internal class PropagationSpecification
    {
        private IPropagation<Signal>[] TestSuiteForPropagation
        {
            get
            {
                return new[]
                {
                    Propagation.WithoutCache.Of<Signal>(),
                    Propagation.WithLatestCache.Of(new GenerateSignal()),
                };
            }
        }

        private ConsumeSignal consumption;

        [SetUp]
        public void SetUp()
        {
            consumption = new ConsumeSignal();
        }

        [Test]
        public void ShouldSendSignalToProducedWhenHasConsumed()
        {
            foreach (var propagation in TestSuiteForPropagation)
            {
                var cancellation = propagation.Produce(consumption);

                var expected = new Signal();

                propagation.Consume(expected);

                Assert.AreEqual(expected, consumption.Consumed);

                cancellation.Cancel();
            }
        }

        [Test]
        public void ShouldNotSendSignalToNotProducedWhenHasConsumed()
        {
            foreach (var propagation in TestSuiteForPropagation)
            {
                var cancellation = propagation.Produce(consumption);

                cancellation.Cancel();

                var expected = new Signal();

                propagation.Consume(expected);

                Assert.AreNotEqual(expected, consumption.Consumed);
            }
        }

        [Test]
        public void ShouldNotSendSignalAfterHasDisposed()
        {
            foreach (var propagation in TestSuiteForPropagation)
            {
                var cancellation = propagation.Produce(consumption);

                propagation.Dispose();

                var expected = new Signal();

                propagation.Consume(expected);

                Assert.AreNotEqual(expected, consumption.Consumed);

                cancellation.Cancel();
            }
        }

        [Test]
        public void ShouldSendCachedSignalToProducedWhenHasProduced()
        {
            var propagation = Propagation.WithLatestCache.Of(new GenerateSignal());

            var expected = new Signal();

            propagation.Consume(expected);

            var cancellation = propagation.Produce(consumption);

            Assert.AreEqual(expected, consumption.Consumed);

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
