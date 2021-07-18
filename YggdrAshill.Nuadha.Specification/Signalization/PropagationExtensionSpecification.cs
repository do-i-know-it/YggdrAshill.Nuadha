using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PropagationExtension))]
    internal class PropagationExtensionSpecification :
        IPropagation<Signal>,
        IGeneration<Signal>,
        ICancellation
    {
        #region Mock of Propagation

        private Signal expected;

        private Signal consumed;


        public void Cancel()
        {

        }

        public void Dispose()
        {

        }

        public Signal Generate()
        {
            if (expected == null)
            {
                throw new InvalidOperationException(nameof(expected));
            }

            return expected;
        }

        public void Consume(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumed = signal;
        }

        public ICancellation Produce(IConsumption<Signal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return this;
        }

        #endregion

        private IPropagation<Signal> propagation;

        private IGeneration<Signal> generation;

        private IConsumption<Signal> consumption;

        [SetUp]
        public void SetUp()
        {
            expected = new Signal();

            propagation = this;

            generation = this;

            consumption = this;
        }

        [Test]
        public void ShouldTransmitSignal()
        {
            var transmission = propagation.ToTransmit(generation);

            var cancellation = transmission.Produce(consumption);

            transmission.Emit();

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotTransmitWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = default(IPropagation<Signal>).ToTransmit(generation);

            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var transmission = propagation.Transmit(default);
            });
        }
    }
}
