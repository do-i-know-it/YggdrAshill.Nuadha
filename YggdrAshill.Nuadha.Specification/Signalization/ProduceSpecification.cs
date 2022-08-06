using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Produce<>))]
    internal class ProduceSpecification
    {
        private ConsumeSignal consumeSignal;

        [SetUp]
        public void SetUp()
        {
            consumeSignal = new ConsumeSignal();
        }

        [Test]
        public void ShouldExecuteActionWhenHasProduced()
        {
            var expected = false;
            var production = Produce<Signal>.With(consumption =>
            {
                expected = true;

                return new FakeCancellation();
            });

            var cancellation = production.Produce(consumeSignal);

            Assert.IsTrue(expected);
        }

        [Test]
        public void ShouldProduceSignal()
        {
            var expected = new Signal();
            var production = Produce<Signal>.With(consumption =>
            {
                consumption.Consume(expected);

                return new FakeCancellation();
            });

            var cancellation = production.Produce(consumeSignal);

            Assert.AreEqual(expected, consumeSignal.Consumed);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = Produce<Signal>.With(default);
            });
        }
    }
}
