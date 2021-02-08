using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Disconnection))]
    internal class DisconnectionSpecification
    {
        [Test]
        public void ShouldExecuteActionWhenHasDisconnected()
        {
            var expected = false;
            var disconnection = new Disconnection(() =>
            {
                expected = true;
            });

            disconnection.Disconnect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = new Disconnection(null);
            });
        }
    }
}
