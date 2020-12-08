using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchEventSystem))]
    internal class TouchEventSystemSpecification
    {
        private IConnector<Touch> connector;

        private TouchEventSystem system;

        private IDisconnection disconnection;

        [SetUp]
        public void SetUp()
        {
            connector = new Connector<Touch>();

            system = new TouchEventSystem();

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
        public void ShouldPulsateWhenHasTouched()
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

            var disconnection = system.HasTouched.Connect(terminal);

            connector.Receive(Touch.Disabled);
            connector.Receive(Touch.Enabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldPulsateWhenIsTouched()
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

            var disconnection = system.IsTouched.Connect(terminal);

            connector.Receive(Touch.Enabled);
            connector.Receive(Touch.Enabled);

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

            connector.Receive(Touch.Enabled);
            connector.Receive(Touch.Disabled);

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

            connector.Receive(Touch.Disabled);
            connector.Receive(Touch.Disabled);

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
