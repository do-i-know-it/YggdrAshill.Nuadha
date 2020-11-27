using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(OutputTerminal<>))]
    internal class OutputTerminalSpecification
    {
        [Test]
        public void ShouldExecuteFunctionWhenHasConnected()
        {
            var expected = false;
            var terminal = new OutputTerminal<Signal>(_ =>
            {
                expected = true;

                return new Disconnection();
            });

            var disconnection = terminal.Connect(new InputTerminal<Signal>());

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldDisconnectAfterHasConnected()
        {
            var expected = false;
            var terminal = new OutputTerminal<Signal>(_ =>
            {
                return new Disconnection(() =>
                {
                    expected = true;
                });
            });

            var disconnection = terminal.Connect(new InputTerminal<Signal>());

            disconnection.Disconnect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var terminal = new OutputTerminal<Signal>(null);
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            var terminal = new OutputTerminal<Signal>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                terminal.Connect(null);
            });
        }
    }
}
