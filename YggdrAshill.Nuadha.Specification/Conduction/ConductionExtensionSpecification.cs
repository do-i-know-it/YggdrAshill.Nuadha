using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConductionExtension))]
    internal class ConductionExtensionSpecification
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
        public void ShouldTransmitSignalWithGeneration()
        {
            var transmission = propagation.Transmit(generation);

            var cancellation = transmission.Produce(consumption);

            transmission.Emit();

            Assert.AreEqual(generation.Generated, consumption.Consumed);

            cancellation.Cancel();
        }

        [Test]
        public void ShouldTransmitSignalWithFunction()
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
                var transmission = default(IPropagation<Signal>).Transmit(generation);

            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = propagation.Transmit(default(IGeneration<Signal>));
            });

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
