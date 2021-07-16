using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Space2D))]
    internal class Space2DSpecification
    {
        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void PositionShouldBeEqualToSameOne(float horizontal, float vertical)
        {
            Assert.AreEqual(new Space2D.Position(horizontal, vertical), new Space2D.Position(horizontal, vertical));
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void PositionShouldNotBeEqualToDifferentOne(float horizontal, float vertical)
        {
            Assert.AreNotEqual(new Space2D.Position(horizontal, vertical), new Space2D.Position(vertical, horizontal));
        }

        [Test]
        public void PositionShouldHaveCoordinate()
        {
            Assert.AreEqual(new Space2D.Position(0f, 0f), Space2D.Position.Origin);
            Assert.AreEqual(new Space2D.Position(1f, 0f), Space2D.Position.Right);
            Assert.AreEqual(new Space2D.Position(-1f, 0f), Space2D.Position.Left);
            Assert.AreEqual(new Space2D.Position(0f, 1f), Space2D.Position.Upward);
            Assert.AreEqual(new Space2D.Position(0f, -1f), Space2D.Position.Downward);
        }

        [TestCase(0.0f, -1.0f, 1.0f)]
        [TestCase(-1.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 1.0f)]
        public void PositionShouldBeAdded(float horizontal, float vertical, float offset)
        {
            var expected = new Space2D.Position(horizontal + offset, vertical + offset);

            Assert.AreEqual(expected, new Space2D.Position(horizontal, vertical) + new Space2D.Position(offset, offset));
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void PositionShouldHaveIdentity(float horizontal, float vertical)
        {
            var position = new Space2D.Position(horizontal, vertical);

            Assert.AreEqual(position, Space2D.Position.Origin + position);
            Assert.AreEqual(position, position + Space2D.Position.Origin);
        }

        [TestCase(0.0f, -1.0f, 1.0f)]
        [TestCase(-1.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 1.0f)]
        public void PositionShouldBeSubtracted(float horizontal, float vertical, float offset)
        {
            var expected = new Space2D.Position(horizontal - offset, vertical - offset);

            Assert.AreEqual(expected, new Space2D.Position(horizontal, vertical) - new Space2D.Position(offset, offset));
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void PositionShouldHaveInverse(float horizontal, float vertical)
        {
            var position = new Space2D.Position(horizontal, vertical);

            Assert.AreEqual(Space2D.Position.Origin, -position + position);
            Assert.AreEqual(Space2D.Position.Origin, position - position);
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void DirectionShouldBeEqualToSameOne(float horizontal, float vertical)
        {
            Assert.AreEqual(new Space2D.Direction(horizontal, vertical), new Space2D.Direction(horizontal, vertical));
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void DirectionShouldNotBeEqualToDifferentOne(float horizontal, float vertical)
        {
            Assert.AreNotEqual(new Space2D.Direction(horizontal, vertical), new Space2D.Direction(vertical, horizontal));
        }

        [Test]
        public void DirectionShouldHaveCoordinate()
        {
            Assert.AreEqual(new Space2D.Direction(1f, 0f), Space2D.Direction.Right);
            Assert.AreEqual(new Space2D.Direction(-1f, 0f), Space2D.Direction.Left);
            Assert.AreEqual(new Space2D.Direction(0f, 1f), Space2D.Direction.Upward);
            Assert.AreEqual(new Space2D.Direction(0f, -1f), Space2D.Direction.Downward);
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void DirectionShouldBeReversed(float horizontal, float vertical)
        {
            Assert.AreEqual(new Space2D.Direction(-horizontal, -vertical), new Space2D.Direction(horizontal, vertical).Reversed);
        }

        [Test]
        public void CannotBeGeneratedWithNaNHorizontal()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var position = new Space2D.Position(float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var direction = new Space2D.Direction(float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var rotation = new Space2D.Rotation(float.NaN, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNVertical()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var position = new Space2D.Position(0.0f, float.NaN);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var direction = new Space2D.Direction(0.0f, float.NaN);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var rotation = new Space2D.Rotation(0.0f, float.NaN);
            });
        }
    }
}
