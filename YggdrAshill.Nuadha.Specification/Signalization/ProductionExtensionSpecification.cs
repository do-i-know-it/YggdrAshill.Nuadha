using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ProductionExtension))]
    internal class ProductionExtensionSpecification
    {
        private Signal expected;

        private PropagateSignal propagation;

        [SetUp]
        public void SetUp()
        {
            expected = new Signal();

            propagation = new PropagateSignal();
        }

        [Test]
        public void ShouldProduceSignal()
        {
            var consumed = default(Signal);
            var cancellation = propagation.Produce(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumed);

            cancellation.Cancel();
        }

        [Test]
        public void CannotProduceWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = default(IPropagation<Signal>).Produce(_ => { });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var cancellation = propagation.Produce(default);
            });
        }
    }
}
