using NUnit.Framework;
using YggdrAshill.Nuadha.Operation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Corrector<>))]
    internal class CorrectorSpecification : ICorrection<Signal>
    {
        private Corrector<Signal> corrector;

        private Connector<Signal> connector;

        public Signal Correct(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return signal;
        }

        [SetUp]
        public void SetUp()
        {
            connector = new Connector<Signal>();

            corrector = new Corrector<Signal>(connector, this);
        }

        [TearDown]
        public void TearDown()
        {
            connector.Disconnect();
            connector = default;

            corrector = default;
        }

        [Test]
        public void ShouldCorrectSignalWhenReceived()
        {
            var expected = false;
            var terminal = new InputTerminal<Signal>(_ =>
            {
                expected = true;
            });

            var disconnection = corrector.Connect(terminal);

            connector.Receive(new Signal());

            Assert.IsTrue(expected);

            disconnection.Disconnect();
        }

        [Test]
        public void CannotBeGeneratedWithNullOutputTerminal()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var corrector = new Corrector<Signal>(null, this);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNullCorrection()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var corrector = new Corrector<Signal>(connector, null);
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = corrector.Connect(null);
            });
        }
    }
}
