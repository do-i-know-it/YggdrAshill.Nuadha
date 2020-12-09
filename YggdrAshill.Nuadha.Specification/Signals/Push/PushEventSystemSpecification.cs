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
        private PushEventSystem system;

        [SetUp]
        public void SetUp()
        {
            system = new PushEventSystem();
        }

        [TearDown]
        public void TearDown()
        {
            system.Disconnect();
            system = default;
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

            system.Receive(Push.Disabled);
            system.Receive(Push.Enabled);

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

            system.Receive(Push.Enabled);
            system.Receive(Push.Enabled);

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

            system.Receive(Push.Enabled);
            system.Receive(Push.Disabled);

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

            system.Receive(Push.Disabled);
            system.Receive(Push.Disabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }
    }
}
