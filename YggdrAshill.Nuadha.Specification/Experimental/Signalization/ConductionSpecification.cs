using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Experimental.Specification
{
    [TestFixture(TestOf = typeof(Conduction<>))]
    internal class ConductionSpecification
    {
        private Conduction<Signal> conduction;
        private Consumption<Signal> consumption;

        private Signal expected;
        private Signal consumed;

        [SetUp]
        public void SetUp()
        {
            expected = new Signal();
            conduction = new Conduction<Signal>(() =>
            {
                return expected;
            });

            consumed = default;
            consumption = new Consumption<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });
        }

        [TearDown]
        public void TearDown()
        {
            conduction.Dispose();
        }

        [Test]
        public void ShouldSendSignalToProducedWhenHasEmitted()
        {
            var cancellation = conduction.Produce(consumption);

            conduction.Emit();

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldNotSendSignalToNotProducedWhenHasEmitted()
        {
            var cancellation = conduction.Produce(consumption);

            cancellation.Cancel();

            conduction.Emit();

            Assert.AreNotEqual(expected, consumed);
        }

        [Test]
        public void ShouldNotSendSignalAfterHasDisposed()
        {
            var cancellation = conduction.Produce(consumption);

            conduction.Dispose();

            conduction.Emit();

            Assert.AreNotEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conduction = new Conduction<Signal>(null);
            });
        }

        [Test]
        public void CannotProduceNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = conduction.Produce(null);
            });
        }
    }
}
