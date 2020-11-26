using NUnit.Framework;
using YggdrAshill.Nuadha.Operation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Pulsator<>))]
    internal class PulsatorSpecification : IPulsation<Signal>
    {
        private Pulsator<Signal> pulsator;

        private Connector<Signal> connector;

        private bool expected;

        public bool Pulsate(Signal previous, Signal current)
        {
            if (previous == null)
            {
                throw new ArgumentNullException(nameof(previous));
            }
            if (current == null)
            {
                throw new ArgumentNullException(nameof(current));
            }

            return expected;
        }

        [SetUp]
        public void SetUp()
        {
            connector = new Connector<Signal>();

            pulsator = new Pulsator<Signal>(connector, this, new Signal());

            expected = false;
        }

        [TearDown]
        public void TearDown()
        {
            connector.Disconnect();
            connector = default;

            pulsator = default;

            expected = false;
        }

        [Test]
        public void ShouldGeneratePulseWhenReceivedSignalHasBeenPulsated()
        {
            var received = false;
            var terminal = new InputTerminal<Pulse>(_ =>
            {
                received = true;
            });

            expected = true;

            var disconnection = pulsator.Connect(terminal);

            connector.Receive(new Signal());

            Assert.AreEqual(expected, received);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldNotGeneratePulseWhenReceivedSignalHasNotBeenPulsated()
        {
            var received = false;
            var terminal = new InputTerminal<Pulse>(_ =>
            {
                received = true;
            });

            expected = false;

            var disconnection = pulsator.Connect(terminal);

            connector.Receive(new Signal());

            Assert.AreEqual(expected, received);

            disconnection.Disconnect();
        }

        [Test]
        public void CannotBeGeneratedWithNullOutputTerminal()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var pulsator = new Pulsator<Signal>(null, this, new Signal());
            });
        }

        [Test]
        public void CannotBeGeneratedWithNullPulsation()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var pulsator = new Pulsator<Signal>(connector, null, new Signal());
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = pulsator.Connect(null);
            });
        }
    }
}
