using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Propagate))]
    internal class PropagateSpecification
    {
        private static object[] TestSuiteForPropagation => new[]
        {
            new object[] { Propagate.WithoutCache<Signal>() },
            new object[] { Propagate.WithLatestCache(new GenerateSignal()) },
        };

        private Signal expected;

        private ConsumeSignal consumption;

        [SetUp]
        public void SetUp()
        {
            expected = new Signal();

            consumption = new ConsumeSignal();
        }

        [TestCaseSource("TestSuiteForPropagation")]
        public void ShouldSendSignalToProducedWhenHasConsumed(IPropagation<Signal> propagation)
        {
            var cancellation = propagation.Produce(consumption);

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumption.Consumed);

            cancellation.Cancel();
        }

        [TestCaseSource("TestSuiteForPropagation")]
        public void ShouldNotSendSignalToNotProducedWhenHasConsumed(IPropagation<Signal> propagation)
        {
            var cancellation = propagation.Produce(consumption);

            cancellation.Cancel();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumption.Consumed);
        }

        [TestCaseSource("TestSuiteForPropagation")]
        public void ShouldNotSendSignalAfterHasDisposed(IPropagation<Signal> propagation)
        {
            var cancellation = propagation.Produce(consumption);

            propagation.Dispose();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumption.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldSendCachedSignalToProducedWhenHasProduced()
        {
            var propagation = Propagate.WithLatestCache(new GenerateSignal());

            propagation.Consume(expected);

            var cancellation = propagation.Produce(consumption);

            Assert.AreEqual(expected, consumption.Consumed);

            cancellation.Cancel();
        }

        [TestCaseSource("TestSuiteForPropagation")]
        public void CannotProduceNull(IPropagation<Signal> propagation)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = propagation.Produce(default);
            });
        }

        [Test]
        public void CannotBeCreatedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var propagation = Propagate.WithLatestCache(default(IGeneration<Signal>));
            });
        }
    }
}
