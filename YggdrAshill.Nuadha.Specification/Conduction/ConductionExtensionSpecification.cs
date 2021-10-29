using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConductionExtension))]
    internal class ConductionExtensionSpecification
    {
        private PropagateSignal propagation;

        private ConsumeSignal consumption;

        [SetUp]
        public void SetUp()
        {
            propagation = new PropagateSignal();

            consumption = new ConsumeSignal();
        }

        [Test]
        public void ShouldTransmitSignal()
        {
            var expected = new Signal();
            var transmission = propagation.Transmit(() =>
            {
                return expected;
            });

            var cancellation = transmission.Produce(consumption);

            transmission.Emit();

            Assert.AreEqual(expected, consumption.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotTransmitWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = default(IPropagation<Signal>).Transmit(() => new Signal());

            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = propagation.Transmit(default(Func<Signal>));
            });
        }
    }
}
