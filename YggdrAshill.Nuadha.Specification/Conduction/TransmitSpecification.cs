using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Transmit))]
    internal class TransmitSpecification
    {
        private GenerateSignal generation;

        private ConsumeSignal consumption;

        [SetUp]
        public void SetUp()
        {
            generation = new GenerateSignal();

            consumption = new ConsumeSignal();
        }

        [Test]
        public void ShouldTransmitSignal()
        {
            var transmission = Transmit.Signal(generation);

            var cancellation = transmission.Produce(consumption);

            transmission.Emit();

            Assert.AreEqual(generation.Generated, consumption.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotTransmitWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = Transmit.Signal(default(IGeneration<Signal>));

            });
        }
    }
}
