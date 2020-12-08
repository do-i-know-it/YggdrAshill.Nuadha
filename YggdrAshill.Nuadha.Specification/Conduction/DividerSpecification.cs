using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Divider<>))]
    internal class DividerSpecification
    {
        private OutputTerminal<Signal> terminal;

        [SetUp]
        public void SetUp()
        {
            terminal = new OutputTerminal<Signal>();
        }

        [TearDown]
        public void TearDown()
        {
            terminal = default;
        }

        [Test]
        public void ShouldExecuteFunctionWhenHasConnected()
        {
            var expected = false;
            var divider = new Divider<Signal>(_ =>
            {
                expected = true;

                return new Disconnection();
            });

            var disconnection = divider.Connect(terminal);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldDisconnectAfterHasConnected()
        {
            var expected = false;
            var divider = new Divider<Signal>(_ =>
            {
                return new Disconnection(() =>
                {
                    expected = true;
                });
            });

            var disconnection = divider.Connect(terminal);

            disconnection.Disconnect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var divider = new Divider<Signal>(null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var divider = new Divider<Signal>((Action<Signal>)null);
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            var divider = new Divider<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = divider.Connect(null);
            });
        }
    }
}
