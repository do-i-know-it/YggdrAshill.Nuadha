using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TransmissionOf))]
    internal class TransmissionOfSpecification
    {
        private PropagateSignal propagation;

        private GenerateSignal generation;

        private ConsumeSignal consumption;

        [SetUp]
        public void SetUp()
        {
            propagation = new PropagateSignal();

            generation = new GenerateSignal();

            consumption = new ConsumeSignal();
        }

        [Test]
        public void ShouldTransmitSignal()
        {
            var transmission = TransmissionOf.Signal(generation, propagation);

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
                var transmission = TransmissionOf.Signal(generation, default(IPropagation<Signal>));

            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = TransmissionOf.Signal(default(IGeneration<Signal>), propagation);
            });
        }
    }
}
