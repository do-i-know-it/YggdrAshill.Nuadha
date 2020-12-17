using NUnit.Framework;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushEventInputSystem))]
    internal class PushEventInputSystemSpecification
    {
        private PushEventInputSystem system;

        [SetUp]
        public void SetUp()
        {
            system = new PushEventInputSystem();
        }

        [TearDown]
        public void TearDown()
        {
            system.Disconnect();
            system = default;
        }

        [Test]
        public void ShouldPulsateWhenHasEnabled()
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

            var disconnection = system.HasEnabled.Connect(terminal);

            system.Receive(Push.Disabled);
            system.Receive(Push.Enabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldPulsateWhenIsEnabled()
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

            var disconnection = system.IsEnabled.Connect(terminal);

            system.Receive(Push.Enabled);
            system.Receive(Push.Enabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldPulsateWhenHasDisabled()
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

            var disconnection = system.HasDisabled.Connect(terminal);

            system.Receive(Push.Enabled);
            system.Receive(Push.Disabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldPulsateWhenIsDisabled()
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

            var disconnection = system.IsDisabled.Connect(terminal);

            system.Receive(Push.Disabled);
            system.Receive(Push.Disabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }
    }
}
