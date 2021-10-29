using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(DetectionExtension))]
    internal class DetectionExtensionSpecification
    {
        private PropagateSignal propagation;

        private SignalCondition condition;

        private ConsumeNotice consumption;

        [SetUp]
        public void SetUp()
        {
            propagation = new PropagateSignal();

            condition = new SignalCondition();

            consumption = new ConsumeNotice();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            condition.Previous = expected;

            var cancellation
                = propagation
                .Detect(condition)
                .Produce(consumption);

            propagation.Consume(new Signal());

            Assert.AreEqual(expected, consumption.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotDetectWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Signal>).Detect(condition);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagation.Detect(default(ICondition<Signal>));
            });
        }
    }
}
