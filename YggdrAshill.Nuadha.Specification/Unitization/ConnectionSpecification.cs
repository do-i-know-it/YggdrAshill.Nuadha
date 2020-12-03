using NUnit.Framework;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Connection<>))]
    internal class ConnectionSpecification
    {
        private Handler handler;

        [SetUp]
        public void SetUp()
        {
            handler = new Handler();
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
            var connection = new Connection<Handler>(handler =>
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handler));
                }

                expected = true;

                return new Disconnection();
            });

            var disconnection = connection.Connect(handler);

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldDisconnectAfterHasConnected()
        {
            var expected = false;
            var connection = new Connection<Handler>(handler =>
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handler));
                }

                return new Disconnection(() =>
                {
                    expected = true;
                });
            });

            var disconnection = connection.Connect(handler);

            disconnection.Disconnect();

            Assert.IsTrue(expected);
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var connection = new Connection<Handler>(null);
            });
        }
    }
}
