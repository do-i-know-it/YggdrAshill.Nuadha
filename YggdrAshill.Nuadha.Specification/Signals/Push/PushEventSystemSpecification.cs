using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushEventSystem))]
    internal class PushEventSystemSpecification
    {
        private IConnector<Push> connector;

        private PushEventSystem system;

        private IDisconnection disconnection;

        [SetUp]
        public void SetUp()
        {
            connector = new Connector<Push>();

            system = new PushEventSystem();

            disconnection = system.Connect(connector);
        }

        [TearDown]
        public void TearDown()
        {
            connector.Disconnect();
            connector = default;

            system.Disconnect();
            system = default;

            disconnection.Disconnect();
            disconnection = default;
        }

        [Test]
        public void ShouldPulsateWhenHasPushed()
        {
            var expected = false;
            var terminal = new InputTerminal<Pulse>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = system.HasPushed.Connect(terminal);

            connector.Receive(Push.Disabled);
            connector.Receive(Push.Enabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldPulsateWhenIsPushed()
        {
            var expected = false;
            var terminal = new InputTerminal<Pulse>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = system.IsPushed.Connect(terminal);

            connector.Receive(Push.Enabled);
            connector.Receive(Push.Enabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldPulsateWhenHasReleased()
        {
            var expected = false;
            var terminal = new InputTerminal<Pulse>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = system.HasReleased.Connect(terminal);

            connector.Receive(Push.Enabled);
            connector.Receive(Push.Disabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldPulsateWhenIsReleased()
        {
            var expected = false;
            var terminal = new InputTerminal<Pulse>(signal =>
            {
                if (signal == null)
                {
                    throw new ArgumentNullException(nameof(signal));
                }

                expected = true;
            });

            var disconnection = system.IsReleased.Connect(terminal);

            connector.Receive(Push.Disabled);
            connector.Receive(Push.Disabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void CannotConnectNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = system.Connect(null);
            });
        }
    }
}
