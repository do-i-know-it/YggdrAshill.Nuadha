using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(DetectionExtension))]
    internal class DetectionExtensionSpecification :
        IDetection<Signal>,
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

        bool IDetection<Signal>.Detect(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        private IProduction<Signal> production;

        private IDetection<Signal> detection;

        [SetUp]
        public void SetUp()
        {
            expected = false;

            consumed = false;

            production = this;

            detection = this;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            this.expected = expected;

            var cancellation = production.Detect(detection).Produce(this);

            consumption.Consume(new Signal());

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotDetectWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Signal>).Convert(detection);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = production.Detect(default(IDetection<Signal>));
            });
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldInverseDetection(bool expected)
        {
            this.expected = expected;

            var inversed = detection.Not();

            var detected = inversed.Detect(new Signal());

            Assert.AreNotEqual(expected, detected);
        }

        [Test]
        public void CannotCombineWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var inversed = default(IDetection<Signal>).Not();
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = default(IDetection<Signal>).And(detection);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var multiplied = detection.And(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var added = default(IDetection<Signal>).Or(detection);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var added = detection.Or(default);
            });
        }
    }
}
