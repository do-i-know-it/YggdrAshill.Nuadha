using NUnit.Framework;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchEventSystem))]
    internal class TouchEventSystemSpecification
    {
        private TouchEventSystem system;

        [SetUp]
        public void SetUp()
        {
            system = new TouchEventSystem();
        }

        [TearDown]
        public void TearDown()
        {
            system.Disconnect();
            system = default;
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

            system.Receive(Touch.Disabled);
            system.Receive(Touch.Enabled);

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

            system.Receive(Touch.Enabled);
            system.Receive(Touch.Enabled);

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

            system.Receive(Touch.Enabled);
            system.Receive(Touch.Disabled);

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

            system.Receive(Touch.Disabled);
            system.Receive(Touch.Disabled);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }
    }
}
