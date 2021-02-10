using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConductionExtension))]
    internal class ConductionExtensionSpecification :
        IConsumption<Signal>
    {
        #region IConsumption

        private Signal consumed;

        public void Consume(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumed = signal;
        }

        #endregion

        [SetUp]
        public void SetUp()
        {
            consumed = default;
        }

        [TearDown]
        public void TearDown()
        {
            consumed = default;
        }

        [Test]
        public void ShouldConnectWithAction()
        {
            var propagation = new Propagation<Signal>();

            var consumed = default(Signal);
            var disconnection = propagation.Connect(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });

            var expected = new Signal();

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumed);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldProduceWithGeneration()
        {
            var expected = new Signal();
            var generation = new Generation<Signal>(() =>
            {
                return expected;
            });

            var emission = generation.Produce(this);

            emission.Emit();

            Assert.AreEqual(expected, consumed);
        }

        [Test]
        public void ShouldBeConvertedToProduction()
        {
            var expected = new Signal();
            var generation = new Generation<Signal>(() =>
            {
                return expected;
            });

            var production = generation.ToProduction();

            var emission = production.Produce(this);

            emission.Emit();

            Assert.AreEqual(expected, consumed);
        }
    }
}
