using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PositionToPosition))]
    internal class PositionToPositionSpecification
    {
        [TestCase(0.0f, 0.0f, 1.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 1.0f)]
        public void ShouldAddOffsetToPosition(float horizontal, float vertical, float frontal, float offset)
        {
            var reduction = PositionToPosition.Add;

            var position = new Position(horizontal, vertical, frontal);
            var expected = new Position(horizontal + offset, vertical + offset, frontal + offset);

            Assert.AreEqual(expected, reduction.Reduce(position, new Position(offset, offset, offset)));
        }

        [TestCase(0.0f, 0.0f, 1.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 1.0f)]
        public void ShouldSubtractOffsetFromPosition(float horizontal, float vertical, float frontal, float offset)
        {
            var reduction = PositionToPosition.Subtract;

            var position = new Position(horizontal, vertical, frontal);
            var expected = new Position(horizontal - offset, vertical - offset, frontal - offset);

            Assert.AreEqual(expected, reduction.Reduce(position, new Position(offset, offset, offset)));
        }
    }
}
