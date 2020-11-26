using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(InputTerminal<>))]
    internal class InputTerminalSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasReceived()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(_ =>
            {
                expected = true;
            });

            terminal.Receive(new Signal());

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var terminal = new InputTerminal<Signal>(null);
            });
        }
    }
}
