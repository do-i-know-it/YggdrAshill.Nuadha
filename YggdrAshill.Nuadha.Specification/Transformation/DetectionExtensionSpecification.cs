using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(DetectionExtension))]
    internal class DetectionExtensionSpecification :
        ICondition<Signal>,
        IProduction<Signal>,
        IConsumption<Notice>,
        ICancellation
    {
        private bool expected;

        private bool consumed;

        private IConsumption<Signal> consumption;

        void ICancellation.Cancel()
        {

        }

        ICancellation IProduction<Signal>.Produce(IConsumption<Signal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            this.consumption = consumption;

            return this;
        }

        void IConsumption<Notice>.Consume(Notice signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumed = true;
        }

        bool ICondition<Signal>.IsSatisfiedBy(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        private IProduction<Signal> production;

        private ICondition<Signal> condition;

        [SetUp]
        public void SetUp()
        {
            expected = false;

            consumed = false;

            production = this;

            condition = this;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            this.expected = expected;

            var cancellation = production.Detect(condition).Produce(this);

            consumption.Consume(new Signal());

            Assert.AreEqual(expected, consumed);

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
                var detected = production.Detect(default(ICondition<Signal>));
            });
        }
    }
}
