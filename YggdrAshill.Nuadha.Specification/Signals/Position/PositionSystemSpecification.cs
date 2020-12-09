using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PositionSystem))]
    internal class PositionSystemSpecification
    {
        private PositionSystem system;

        private readonly float offset = 1.0f;

        [SetUp]
        public void SetUp()
        {
            system = new PositionSystem(new Position(offset, offset, offset));
        }

        [TearDown]
        public void TearDown()
        {
            system.Disconnect();
            system = default;
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

            system.Receive(position);

            Assert.AreEqual(expected, received);

            disconnection.Disconnect();
        }
    }
}
