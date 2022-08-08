using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConsumeToDetect<>))]
    internal class ConsumeToDetectSpecification :
        IConsumption<Pulse>
    {
        private bool detected;

        void IConsumption<Pulse>.Consume(Pulse signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            detected = true;
        }

        private SignalIsExpected signalIsExpected;

        [SetUp]
        public void SetUp()
        {
            signalIsExpected = new SignalIsExpected();

            detected = false;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            signalIsExpected.Expected = expected;

            var consumption = new ConsumeToDetect<Signal>(signalIsExpected, this);

            consumption.Consume(new Signal());

            Assert.AreEqual(signalIsExpected.Expected, detected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = new ConsumeToDetect<Signal>(default, this);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var consumption = new ConsumeToDetect<Signal>(signalIsExpected, default);
            });
        }
    }
}
