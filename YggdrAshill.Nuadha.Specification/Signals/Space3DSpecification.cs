using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Space3D))]
    internal class Space3DSpecification
    {
        #region Position

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void PositionShouldBeEqualToSameOne(float horizontal, float vertical, float frontal)
        {
            Assert.AreEqual(new Space3D.Position(horizontal, vertical, frontal), new Space3D.Position(horizontal, vertical, frontal));

            Assert.IsTrue(new Space3D.Position(horizontal, vertical, frontal) == new Space3D.Position(horizontal, vertical, frontal));
        }

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void PositionShouldNotBeEqualToDifferentOne(float horizontal, float vertical, float frontal)
        {
            Assert.AreNotEqual(new Space3D.Position(horizontal, vertical, frontal), new Space3D.Position(-horizontal, -vertical, -frontal));

            Assert.IsTrue(new Space3D.Position(horizontal, vertical, frontal) != new Space3D.Position(-horizontal, -vertical, -frontal));
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
            var signal = new Space3D.Position(horizontal, vertical, frontal);

            Assert.AreEqual(signal, Space3D.Position.Origin + signal);
            Assert.AreEqual(signal, signal + Space3D.Position.Origin);
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
            var signal = new Space3D.Position(horizontal, vertical, frontal);

            Assert.AreEqual(Space3D.Position.Origin, -signal + signal);
            Assert.AreEqual(Space3D.Position.Origin, signal - signal);
        }

        [Test]
        public void PositionCannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Position(float.NaN, 0.0f, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Position(0.0f, float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Position(0.0f, 0.0f, float.NaN);
            });
        }

        #endregion

        #region Direction

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void DirectionShouldBeEqualToSameOne(float horizontal, float vertical, float frontal)
        {
            Assert.AreEqual(new Space3D.Direction(horizontal, vertical, frontal), new Space3D.Direction(horizontal, vertical, frontal));

            Assert.IsTrue(new Space3D.Direction(horizontal, vertical, frontal) == new Space3D.Direction(horizontal, vertical, frontal));
        }

        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        public void DirectionShouldNotBeEqualToDifferentOne(float horizontal, float vertical, float frontal)
        {
            Assert.AreNotEqual(new Space3D.Direction(horizontal, vertical, frontal), new Space3D.Direction(-horizontal, -vertical, -frontal));

            Assert.IsTrue(new Space3D.Direction(horizontal, vertical, frontal) != new Space3D.Direction(-horizontal, -vertical, -frontal));
        }

        [Test]
        public void DirectionShouldBeGeneratedWithinValidLength()
        {
            var value = MathF.Sqrt(Space3D.Direction.Maximum / 3);

            Assert.DoesNotThrow(() =>
            {
                var signal = new Space3D.Direction(value, value, value);
            });
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
        public void DirectionShouldBeInversed(float horizontal, float vertical, float frontal)
        {
            var signal = new Space3D.Direction(horizontal, vertical, frontal);

            var expected = new Space3D.Direction(-horizontal, -vertical, -frontal);

            Assert.AreEqual(expected, -signal);
        }

        [Test]
        public void DirectionCannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Direction(float.NaN, 0.0f, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Direction(0.0f, float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Direction(0.0f, 0.0f, float.NaN);
            });
        }

        [Test]
        public void DirectionCannotBeGeneratedWithValueOutOfRange()
        {
            // Horizontal lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Direction(Space3D.Direction.Minimum - 0.1f, 0.0f, 0.0f);
            });

            // Horizontal higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Direction(Space3D.Direction.Maximum + 0.1f, 0.0f, 0.0f);
            });

            // Vertical lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Direction(0.0f, Space3D.Direction.Minimum - 0.1f, 0.0f);
            });

            // Vertical higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Direction(0.0f, Space3D.Direction.Maximum + 0.1f, 0.0f);
            });

            // Frontal lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Direction(0.0f, 0.0f, Space3D.Direction.Minimum - 0.1f);
            });

            // Frontal higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Direction(0.0f, 0.0f, Space3D.Direction.Maximum + 0.1f);
            });
        }

        #endregion

        #region Rotation

        [TestCase(0.0f, 0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, 0.0f, -1.0f, 0.0f)]
        [TestCase(0.0f, -1.0f, 0.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 0.0f)]
        public void RotationShouldBeEqualToSameOne(float horizontal, float vertical, float frontal, float real)
        {
            Assert.AreEqual(new Space3D.Rotation(horizontal, vertical, frontal, real), new Space3D.Rotation(horizontal, vertical, frontal, real));

            Assert.IsTrue(new Space3D.Rotation(horizontal, vertical, frontal, real) == new Space3D.Rotation(horizontal, vertical, frontal, real));

            Assert.IsTrue(new Space3D.Rotation(horizontal, vertical, frontal, real) == new Space3D.Rotation(-horizontal, -vertical, -frontal, -real));
        }

        [TestCase(0.0f, 0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, 0.0f, -1.0f, 0.0f)]
        [TestCase(0.0f, -1.0f, 0.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 0.0f)]
        public void RotationShouldNotBeEqualToDifferentOne(float horizontal, float vertical, float frontal, float real)
        {
            Assert.AreNotEqual(new Space3D.Rotation(horizontal, vertical, frontal, real), new Space3D.Rotation(real, frontal, vertical, horizontal));

            Assert.IsTrue(new Space3D.Rotation(horizontal, vertical, frontal, real) != new Space3D.Rotation(real, frontal, vertical, horizontal));
        }

        [Test]
        public void RotationShouldBeGeneratedWithinValidLength()
        {
            var value = MathF.Sqrt(Space3D.Direction.Maximum / 4);

            Assert.DoesNotThrow(() =>
            {
                var signal = new Space3D.Rotation(value, value, value, value);
            });
        }

        [TestCase(0.0f, 0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, 0.0f, -1.0f, 0.0f)]
        [TestCase(0.0f, -1.0f, 0.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 0.0f)]
        public void RotationShouldHaveIdentity(float horizontal, float vertical, float frontal, float real)
        {
            var signal = new Space3D.Rotation(horizontal, vertical, frontal, real);

            Assert.AreEqual(signal, Space3D.Rotation.None + signal);
            Assert.AreEqual(signal, signal + Space3D.Rotation.None);
        }

        [TestCase(0.0f, 0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, 0.0f, -1.0f, 0.0f)]
        [TestCase(0.0f, -1.0f, 0.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 0.0f)]
        public void RotationShouldHaveInverse(float horizontal, float vertical, float frontal, float real)
        {
            var signal = new Space3D.Rotation(horizontal, vertical, frontal, real);

            Assert.AreEqual(Space3D.Rotation.None, signal - signal);
            Assert.AreEqual(Space3D.Rotation.None, -signal + signal);
        }

        [Test]
        public void RotationCannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Rotation(float.NaN, 0.0f, 0.0f, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, float.NaN, 0.0f, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, 0.0f, float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, 0.0f, 0.0f, float.NaN);
            });
        }

        [Test]
        public void RotationCannotBeGeneratedWithValueOutOfRange()
        {
            // Horizontal lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Rotation(Space3D.Rotation.Minimum - 0.1f, 0.0f, 0.0f, 0.0f);
            });

            // Horizontal higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Rotation(Space3D.Rotation.Maximum + 0.1f, 0.0f, 0.0f, 0.0f);
            });

            // Vertical lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, Space3D.Rotation.Minimum - 0.1f, 0.0f, 0.0f);
            });

            // Vertical higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, Space3D.Rotation.Maximum + 0.1f, 0.0f, 0.0f);
            });

            // Frontal lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, 0.0f, Space3D.Rotation.Minimum - 0.1f, 0.0f);
            });

            // Frontal higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, 0.0f, Space3D.Rotation.Maximum + 0.1f, 0.0f);
            });

            // Real lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, 0.0f, 0.0f, Space3D.Rotation.Minimum - 0.1f);
            });

            // Real higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Space3D.Rotation(0.0f, 0.0f, 0.0f, Space3D.Rotation.Maximum + 0.1f);
            });
        }

        #endregion
    }
}
