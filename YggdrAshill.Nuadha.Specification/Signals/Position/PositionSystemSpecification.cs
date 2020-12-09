using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PositionSystem))]
    internal class PositionSystemSpecification
    {
        private IConnector<Position> connector;
        private IOutputTerminal<Position> Terminal => connector;

        private PositionSystem system;

        private IDisconnection disconnection;

        private readonly float offset = 1.0f;

        [SetUp]
        public void SetUp()
        {
            connector = new Connector<Position>();

            system = new PositionSystem(new Position(offset, offset, offset));

            disconnection = system.Connect(Terminal);
        }

        [TearDown]
        public void TearDown()
        {
            connector.Disconnect();
            connector = default;

            system.Disconnect();
            system = default;

            disconnection.Disconnect();
            disconnection = default;
        }

        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f)]
        public void ShouldReceiveCalibratedPosition(float horizontal, float vertical, float frontal)
        {
            var received = default(Position);
            var terminal = new InputTerminal<Position>(signal =>
            {
                received = signal;
            });

            var disconnection = system.Connect(terminal);

            var position = new Position(horizontal, vertical, frontal);

            var expected = new Position(horizontal + offset, vertical + offset, frontal + offset);

            connector.Receive(position);

            Assert.AreEqual(expected, received);

            disconnection.Disconnect();
        }
    }
}
