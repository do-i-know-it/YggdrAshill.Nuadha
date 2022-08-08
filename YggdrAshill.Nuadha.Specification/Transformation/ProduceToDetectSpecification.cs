using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ProduceToDetect<>))]
    internal class ProduceToDetectSpecification :
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

        private PropagateSignal propagateSignal;

        private SignalIsExpected signalIsExpected;

        [SetUp]
        public void SetUp()
        {
            propagateSignal = new PropagateSignal();

            signalIsExpected = new SignalIsExpected();

            detected = false;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignal(bool expected)
        {
            signalIsExpected.Expected = expected;

            var production = new ProduceToDetect<Signal>(propagateSignal, signalIsExpected);

            var cancellation = production.Produce(this);

            propagateSignal.Consume(new Signal());

            Assert.AreEqual(expected, detected);

            cancellation.Cancel();
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = new ProduceToDetect<Signal>(default, signalIsExpected);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var production = new ProduceToDetect<Signal>(propagateSignal, default);
            });
        }
    }
}
