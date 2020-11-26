using NUnit.Framework;
using YggdrAshill.Nuadha.Operation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Detector<>))]
    internal class DetectorSpecification : IDetection<Signal>
    {
        private Detector<Signal> detector;

        private Connector<Signal> connector;

        private bool expected;

        public bool Detect(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        [SetUp]
        public void SetUp()
        {
            connector = new Connector<Signal>();

            detector = new Detector<Signal>(connector, this);

            expected = false;
        }

        [TearDown]
        public void TearDown()
        {
            connector.Disconnect();
            connector = default;

            detector = default;

            expected = false;
        }

        [Test]
        public void ShouldPassSignalWhenReceivedSignalHasBeenDetected()
        {
            var received = false;
            var terminal = new InputTerminal<Signal>(_ =>
            {
                received = true;
            });

            expected = true;

            var disconnection = detector.Connect(terminal);

            connector.Receive(new Signal());

            Assert.AreEqual(expected, received);

            disconnection.Disconnect();
        }

        [Test]
        public void ShouldNotPassSignalWhenReceivedSignalHasNotBeenDetected()
        {
            var received = false;
            var terminal = new InputTerminal<Signal>(_ =>
            {
                received = true;
            });

            expected = false;

            var disconnection = detector.Connect(terminal);

            connector.Receive(new Signal());

            Assert.AreEqual(expected, received);

            disconnection.Disconnect();
        }

        [Test]
        public void CannotBeGeneratedWithNullOutputTerminal()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detector = new Detector<Signal>(null, this);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNullPulsation()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detector = new Detector<Signal>(connector, null);
            });
        }

        [Test]
        public void CannotConnectNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var disconnection = detector.Connect(null);
            });
        }
    }
}
