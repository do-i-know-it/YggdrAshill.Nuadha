using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Software<>))]
    internal class SoftwareSpecification
    {
        private SoftwareHandler handler;

        [SetUp]
        public void SetUp()
        {
            handler = new SoftwareHandler();
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
            var software = new Software<SoftwareHandler>(_ =>
            {
                expected = true;

                return new Disconnection();
            });

            var disconnection = software.Connect(handler);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldDisconnectAfterHasConnected()
        {
            var expected = false;
            var software = new Software<SoftwareHandler>(_ =>
            {
                return new Disconnection(() =>
                {
                    expected = true;
                });
            });

            var disconnection = software.Connect(handler);

            disconnection.Disconnect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var software = new Software<SoftwareHandler>(null);
            });
        }
    }
}
