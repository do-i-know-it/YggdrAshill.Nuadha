using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Produce<>))]
    internal class ProduceSpecification :
        ICancellation
    {
        void ICancellation.Cancel()
        {

        }

        private ConsumeSignal consumeSignal;

        [SetUp]
        public void SetUp()
        {
            consumeSignal = new ConsumeSignal();
        }

        [Test]
        public void ShouldProduceSignal()
        {
            var expected = new Signal();
            var production = Produce<Signal>.Like(consumption =>
            {
                consumption.Consume(expected);

                return this;
            });

            var cancellation = production.Produce(consumeSignal);

            Assert.AreEqual(expected, consumeSignal.Consumed);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = Produce<Signal>.Like(default);
            });
        }
    }
}
