using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(ConductionExtension))]
    internal class ConductionExtensionSpecification
    {
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
