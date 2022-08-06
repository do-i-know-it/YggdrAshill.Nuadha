using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Propagate<>))]
    internal class PropagateSpecification
    {
        private static object[] TestSuiteForPropagation => new[]
        {
            new object[] { Propagate<Signal>.WithoutCache() },
            new object[] { Propagate<Signal>.WithLatestCache(new Signal()) },
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

        [Test]
        public void ShouldSendCachedSignalToProducedWhenHasProduced()
        {
            var propagation = Propagate<Signal>.WithLatestCache(new Signal());

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
    }
}
