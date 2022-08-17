using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Space2D))]
    internal class Space2DSpecification
    {
        #region Position

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void PositionShouldBeEqualToSameOne(float horizontal, float vertical)
        {
            Assert.AreEqual(new Space2D.Position(horizontal, vertical), new Space2D.Position(horizontal, vertical));

            Assert.IsTrue(new Space2D.Position(horizontal, vertical) == new Space2D.Position(horizontal, vertical));
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void PositionShouldNotBeEqualToDifferentOne(float horizontal, float vertical)
        {
            Assert.AreNotEqual(new Space2D.Position(horizontal, vertical), new Space2D.Position(-horizontal, -vertical));

            Assert.IsTrue(new Space2D.Position(horizontal, vertical) != new Space2D.Position(-horizontal, -vertical));
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
            var signal = new Space2D.Position(horizontal, vertical);

            Assert.AreEqual(signal, Space2D.Position.Origin + signal);
            Assert.AreEqual(signal, signal + Space2D.Position.Origin);
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
            var signal = new Space2D.Position(horizontal, vertical);

            Assert.AreEqual(Space2D.Position.Origin, -signal + signal);
            Assert.AreEqual(Space2D.Position.Origin, signal - signal);
        }

        [Test]
        public void PositionCannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space2D.Position(float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space2D.Position(0.0f, float.NaN);
            });
        }

        #endregion

        #region Rotation

        [TestCase(0.0f, Space2D.Rotation.Minimum)]
        [TestCase(Space2D.Rotation.Minimum, 0.0f)]
        [TestCase(0.0f, Space2D.Rotation.Maximum)]
        [TestCase(Space2D.Rotation.Maximum, 0.0f)]
        public void RotationShouldBeEqualToSameOne(float horizontal, float vertical)
        {
            Assert.AreEqual(new Space2D.Rotation(horizontal, vertical), new Space2D.Rotation(horizontal, vertical));

            Assert.IsTrue(new Space2D.Rotation(horizontal, vertical) == new Space2D.Rotation(horizontal, vertical));
        }

        [TestCase(0.0f, Space2D.Rotation.Minimum)]
        [TestCase(Space2D.Rotation.Minimum, 0.0f)]
        [TestCase(0.0f, Space2D.Rotation.Maximum)]
        [TestCase(Space2D.Rotation.Maximum, 0.0f)]
        public void RotationShouldNotBeEqualToDifferentOne(float horizontal, float vertical)
        {
            Assert.AreNotEqual(new Space2D.Rotation(horizontal, vertical), new Space2D.Rotation(vertical, horizontal));

            Assert.IsTrue(new Space2D.Rotation(horizontal, vertical) != new Space2D.Rotation(vertical, horizontal));
        }

        [TestCase(0.0f, Space2D.Rotation.Minimum)]
        [TestCase(Space2D.Rotation.Minimum, 0.0f)]
        [TestCase(0.0f, Space2D.Rotation.Maximum)]
        [TestCase(Space2D.Rotation.Maximum, 0.0f)]
        public void RotationShouldHaveIdentity(float horizontal, float vertical)
        {
            var signal = new Space2D.Rotation(horizontal, vertical);

            Assert.AreEqual(signal, Space2D.Rotation.None + signal);
            Assert.AreEqual(signal, signal + Space2D.Rotation.None);
        }

        [TestCase(0.0f, Space2D.Rotation.Minimum)]
        [TestCase(Space2D.Rotation.Minimum, 0.0f)]
        [TestCase(0.0f, Space2D.Rotation.Maximum)]
        [TestCase(Space2D.Rotation.Maximum, 0.0f)]
        public void RotationShouldHaveInverse(float horizontal, float vertical)
        {
            var signal = new Space2D.Rotation(horizontal, vertical);

            Assert.AreEqual(Space2D.Rotation.None, signal - signal);
            Assert.AreEqual(Space2D.Rotation.None, -signal + signal);
        }

        [Test]
        public void RotationCannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space2D.Rotation(float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space2D.Rotation(0.0f, float.NaN);
            });
        }

        [Test]
        public void RotationCannotBeGeneratedWithValueOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space2D.Rotation(Space2D.Rotation.Minimum - 0.1f, 0.0f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space2D.Rotation(Space2D.Rotation.Maximum + 0.1f, 0.0f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space2D.Rotation(0.0f, Space2D.Rotation.Minimum - 0.1f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space2D.Rotation(0.0f, Space2D.Rotation.Maximum + 0.1f);
            });
        }

        #endregion
    }
}
