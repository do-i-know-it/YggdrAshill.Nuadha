using NUnit.Framework;
using YggdrAshill.Nuadha.Signals.Experimental;
using System;

namespace YggdrAshill.Nuadha.Experimental.Specification
{
    [TestFixture(TestOf = typeof(Space3D))]
    internal class Space3DSpecification
    {
        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void PositionShouldBeEqualToSameOne(float horizontal, float vertical, float frontal)
        {
            Assert.AreEqual(new Space3D.Position(horizontal, vertical, frontal), new Space3D.Position(horizontal, vertical, frontal));
        }

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void PositionShouldNotBeEqualToDifferentOne(float horizontal, float vertical, float frontal)
        {
            Assert.AreNotEqual(new Space3D.Position(horizontal, vertical, frontal), new Space3D.Position(vertical, frontal, horizontal));
        }

        [Test]
        public void PositionShouldHaveCoordinate()
        {
            Assert.AreEqual(new Space3D.Position(0f, 0f, 0f), Space3D.Position.Origin);
            Assert.AreEqual(new Space3D.Position(1f, 0f, 0f), Space3D.Position.Right);
            Assert.AreEqual(new Space3D.Position(-1f, 0f, 0f), Space3D.Position.Left);
            Assert.AreEqual(new Space3D.Position(0f, 1f, 0f), Space3D.Position.Upward);
            Assert.AreEqual(new Space3D.Position(0f, -1f, 0f), Space3D.Position.Downward);
            Assert.AreEqual(new Space3D.Position(0f, 0f, 1f), Space3D.Position.Forward);
            Assert.AreEqual(new Space3D.Position(0f, 0f, -1f), Space3D.Position.Backward);
        }

        [TestCase(0.0f, 0.0f, -1.0f, 1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f, 1.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 1.0f)]
        public void PositionShouldBeAdded(float horizontal, float vertical, float frontal, float offset)
        {
            var expected = new Space3D.Position(horizontal + offset, vertical + offset, frontal + offset);

            Assert.AreEqual(expected, new Space3D.Position(horizontal, vertical, frontal) + new Space3D.Position(offset, offset, offset));
        }

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void PositionShouldHaveIdentity(float horizontal, float vertical, float frontal)
        {
            var position = new Space3D.Position(horizontal, vertical, frontal);

            Assert.AreEqual(position, Space3D.Position.Origin + position);
            Assert.AreEqual(position, position + Space3D.Position.Origin);
        }

        [TestCase(0.0f, 0.0f, -1.0f, 1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f, 1.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 1.0f)]
        public void PositionShouldBeSubtracted(float horizontal, float vertical, float frontal, float offset)
        {
            var expected = new Space3D.Position(horizontal - offset, vertical - offset, frontal - offset);

            Assert.AreEqual(expected, new Space3D.Position(horizontal, vertical, frontal) - new Space3D.Position(offset, offset, offset));
        }

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void PositionShouldHaveInverse(float horizontal, float vertical, float frontal)
        {
            var position = new Space3D.Position(horizontal, vertical, frontal);

            Assert.AreEqual(Space3D.Position.Origin, -position + position);
            Assert.AreEqual(Space3D.Position.Origin, position - position);
        }

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void DirectionShouldBeEqualToSameOne(float horizontal, float vertical, float frontal)
        {
            Assert.AreEqual(new Space3D.Direction(horizontal, vertical, frontal), new Space3D.Direction(horizontal, vertical, frontal));
        }

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void DirectionShouldNotBeEqualToDifferentOne(float horizontal, float vertical, float frontal)
        {
            Assert.AreNotEqual(new Space3D.Direction(horizontal, vertical, frontal), new Space3D.Direction(vertical, frontal, horizontal));
        }

        [Test]
        public void DirectionShouldHaveCoordinate()
        {
            Assert.AreEqual(new Space3D.Direction(1f, 0f, 0f), Space3D.Direction.Right);
            Assert.AreEqual(new Space3D.Direction(-1f, 0f, 0f), Space3D.Direction.Left);
            Assert.AreEqual(new Space3D.Direction(0f, 1f, 0f), Space3D.Direction.Upward);
            Assert.AreEqual(new Space3D.Direction(0f, -1f, 0f), Space3D.Direction.Downward);
            Assert.AreEqual(new Space3D.Direction(0f, 0f, 1f), Space3D.Direction.Forward);
            Assert.AreEqual(new Space3D.Direction(0f, 0f, -1f), Space3D.Direction.Backward);
        }

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void DirectionShouldBeReversed(float horizontal, float vertical, float frontal)
        {
            Assert.AreEqual(new Space3D.Direction(-horizontal, -vertical, -frontal), new Space3D.Direction(horizontal, vertical, frontal).Reversed);
        }

        [Test]
        public void CannotBeGeneratedWithNaNHorizontal()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var position = new Space3D.Position(float.NaN, 0.0f, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var direction = new Space3D.Direction(float.NaN, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNVertical()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var position = new Space3D.Position(0.0f, float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var direction = new Space3D.Direction(0.0f, float.NaN, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNFrontal()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var position = new Space3D.Position(0.0f, 0.0f, float.NaN);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var direction = new Space3D.Direction(0.0f, 0.0f, float.NaN);
            });
        }
    }
}
