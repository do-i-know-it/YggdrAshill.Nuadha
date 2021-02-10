using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Propagation<>))]
    internal class PropagationSpecification :
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

        private Propagation<Signal> propagation;

        [SetUp]
        public void SetUp()
        {
            propagation = new Propagation<Signal>();

            consumed = default;
        }

        [TearDown]
        public void TearDown()
        {
            consumed = default;

            propagation.Disconnect();
            propagation = default;
        }

        [Test]
        public void ShouldSendSignalToConnectedWhenHasConsumed()
        {
            var disconnection = propagation.Connect(this);

            var expected = new Signal();

            propagation.Consume(expected);

            Assert.AreEqual(expected, consumed);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldNotSendSignalToDisconnectedWhenHasConsumed()
        {
            var disconnection = propagation.Connect(this);

            disconnection.Disconnect();

            var expected = new Signal();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumed);
        }

        [Test]
        public void ShouldNotSendSignalAfterHasDisconnected()
        {
            var disconnection = propagation.Connect(this);

            propagation.Disconnect();

            var expected = new Signal();

            propagation.Consume(expected);

            Assert.AreNotEqual(expected, consumed);
        }

        [Test]
        public void CannotConnectNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                propagation.Connect(null);
            });
        }
    }
}
