using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Propagate<>))]
    internal class PropagateSpecification
    {
        private readonly Signal expected = new Signal();

        private ConsumeSignal consumeSignal;

        [SetUp]
        public void SetUp()
        {
            consumeSignal = new ConsumeSignal();
        }

        [Test]
        public void ShouldConsumeSignalToSendAfterHasProduced()
        {
            var propagation = Propagate<Signal>.WithList();

            var cancellation = propagation.Produce(consumeSignal);

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumeSignal.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldConsumeSignalButNotSendAfterHasDisposed()
        {
            var propagation = Propagate<Signal>.WithList();

            var cancellation = propagation.Produce(consumeSignal);

            cancellation.Cancel();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumeSignal.Consumed);
        }

        [Test]
        public void CannotProduceSignalToNull()
        {
            var propagation = Propagate<Signal>.WithList();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = propagation.Produce(default);
            });
        }
    }
}
