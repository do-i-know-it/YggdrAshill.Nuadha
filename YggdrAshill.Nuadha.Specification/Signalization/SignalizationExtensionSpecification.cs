using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(SignalizationExtension))]
    internal class SignalizationExtensionSpecification
    {
        [Test]
        public void ShouldProduceWithAction()
        {
            var expected = new Signal();
            var production = new Production<Signal>(consumption =>
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return new Emission(() =>
                {
                    consumption.Consume(expected);
                });
            });

            var consumed = default(Signal);
            var emission = production.Produce(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                consumed = signal;
            });

            emission.Emit();

            Assert.AreEqual(expected, consumed);
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
    }
}
