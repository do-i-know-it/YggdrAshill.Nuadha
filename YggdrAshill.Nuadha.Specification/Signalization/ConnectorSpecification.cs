using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Connector<>))]
    internal class ConnectorSpecification
    {
        private Connector<Signal> connector;

        [SetUp]
        public void SetUp()
        {
            connector = new Connector<Signal>();
        }

        [TearDown]
        public void TearDown()
        {
            connector.Disconnect();
            connector = default;
        }

        [Test]
        public void ShouldSendSignalToConnectedWhenHasReceived()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = connector.Connect(terminal);

            connector.Receive(new Signal());

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldNotSendSignalToDisconnectedWhenHasReceived()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = connector.Connect(terminal);

            disconnection.Disconnect();

            connector.Receive(new Signal());

            Assert.IsFalse(expected);
        }

        [Test]
        public void ShouldNotSendSignalAfterHasDisconnected()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = connector.Connect(terminal);

            connector.Disconnect();

            connector.Receive(new Signal());

            Assert.IsFalse(expected);
        }

        [Test]
        public void CannotConnectNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                connector.Connect(null);
            });
        }
    }
}
