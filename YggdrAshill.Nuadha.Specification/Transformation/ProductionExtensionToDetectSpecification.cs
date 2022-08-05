using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ProductionExtensionToDetect))]
    internal class ProductionExtensionToDetectSpecification
    {
        private PropagateSignal propagateSignal;

        private NotifySignal notifySignal;

        private ConsumePulse consumePulse;

        [SetUp]
        public void SetUp()
        {
            propagateSignal = new PropagateSignal();

            notifySignal = new NotifySignal();

            consumePulse = new ConsumePulse();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignalWithNotification(bool expected)
        {
            notifySignal.Expected = expected;

            var cancellation
                = propagateSignal
                .Detect(notifySignal)
                .Produce(consumePulse);

            propagateSignal.Consume(new Signal());

            Assert.AreEqual(expected, consumePulse.Consumed);

            cancellation.Cancel();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldDetectSignalWithFunction(bool expected)
        {
            var consumed = false;
            var cancellation
                = propagateSignal
                .Detect(signal =>
                {
                    if (signal == null)
                    {
                        throw new ArgumentNullException(nameof(signal));
                    }

                    return expected;
                })
                .Produce(() =>
                {
                    consumed = true;
                });

            propagateSignal.Consume(new Signal());

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotDetectSignalWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Signal>).Detect(notifySignal);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagateSignal.Detect(default(INotification<Signal>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Signal>).Detect(_ => false);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagateSignal.Detect(default(Func<Signal, bool>));
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = default(IProduction<Pulse>).Produce(() => { });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var detected = propagateSignal.Detect(_ => false).Produce(default(Action));
            });
        }
    }
}
