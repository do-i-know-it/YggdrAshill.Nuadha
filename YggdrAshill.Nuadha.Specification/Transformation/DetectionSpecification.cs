using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Detection))]
    internal class DetectionSpecification
    {
        private PropagateSignal propagateSignal;

        private SignalCondition condition;

        private ConsumeNotice consumeSignal;

        [SetUp]
        public void SetUp()
        {
            propagateSignal = new PropagateSignal();

            condition = new SignalCondition();

            consumeSignal = new ConsumeNotice();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldConsumeSignalToDetect(bool expected)
        {
            condition.Previous = expected;

            var consumption = Detection.Consume(condition, consumeSignal);

            consumption.Consume(new Signal());

            Assert.AreEqual(expected, consumeSignal.Consumed);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldProduceSignalToDetect(bool expected)
        {
            condition.Previous = expected;

            var production = Detection.Produce(propagateSignal, condition);

            var cancellation = production.Produce(consumeSignal);

            propagateSignal.Consume(new Signal());

            Assert.AreEqual(expected, consumeSignal.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotConsumeSignalToDetectWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = Detection.Consume(condition, default(IConsumption<Notice>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = Detection.Consume(default(ICondition<Signal>), consumeSignal);
            });
        }

        [Test]
        public void CannotProduceSignalToDetectWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = Detection.Produce(propagateSignal, default(ICondition<Signal>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = Detection.Produce(default(IProduction<Signal>), condition);
            });
        }
    }
}
