using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Hardware<>))]
    internal class HardwareSpecification
    {
        private HardwareHandler handler;

        [SetUp]
        public void SetUp()
        {
            handler = new HardwareHandler();
        }

        [TearDown]
        public void TearDown()
        {
            handler = default;
        }

        [Test]
        public void ShouldExecuteFunctionWhenHasConnected()
        {
            var expected = false;
            var hardware = new Hardware<HardwareHandler>(_ =>
            {
                expected = true;

                return new Disconnection();
            });

            var disconnection = hardware.Connect(handler);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldDisconnectAfterHasConnected()
        {
            var expected = false;
            var hardware = new Hardware<HardwareHandler>(_ =>
            {
                return new Disconnection(() =>
                {
                    expected = true;
                });
            });

            var disconnection = hardware.Connect(handler);

            disconnection.Disconnect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var hardware = new Hardware<HardwareHandler>(null);
            });
        }
    }
}
