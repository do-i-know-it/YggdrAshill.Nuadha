using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Calibrate))]
    internal class CalibrateSpecification
    {
        [TestCase(0.0f, 0.0f, 1.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 1.0f)]
        public void ShouldCalibratePosition(float horizontal, float vertical, float frontal, float offset)
        {
            var reduction = Calibrate.Position;

            var expected = new Position(horizontal + offset, vertical + offset, frontal + offset);

            Assert.AreEqual(expected, reduction.Reduce(new Position(horizontal, vertical, frontal), new Position(offset, offset, offset)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldCalibrateRotation(float angle)
        {
            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var reduction = Calibrate.Rotation;

            var expected = RotationOf(Direction.Up, new Angle(angle * 2));

            Assert.IsTrue(AreEqual(expected, reduction.Reduce(rotation, rotation)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldBeInversed(float angle)
        {
            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var reduction = Calibrate.Rotation;

            Assert.IsTrue(AreEqual(Rotation.None, reduction.Reduce(rotation, rotation.Inversed)));

            Assert.IsTrue(AreEqual(Rotation.None, reduction.Reduce(rotation.Inversed, rotation)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        public void ShouldNotBeAlwaysCommutative(float angle)
        {
            var left = RotationOf(Direction.Forward, new Angle(angle));
            var right = RotationOf(Direction.Up, new Angle(angle));

            var reduction = Calibrate.Rotation;

            var leftRight = reduction.Reduce(left, right);
            var rightLeft = reduction.Reduce(right, left);

            Assert.IsFalse(AreEqual(leftRight, rightLeft));
        }

        [TestCase(-180.0f)]
        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(180.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldNotBeRotated(float angle)
        {
            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var reduction = Calibrate.Rotation;

            Assert.AreEqual(rotation, reduction.Reduce(rotation, Rotation.None));
         
            Assert.AreEqual(rotation, reduction.Reduce(Rotation.None, rotation));
        }

        private static Rotation RotationOf(Direction axis, Angle angle)
        {
            const float DegreeToRadian = (float)Math.PI / 180.0f;
            var theta = angle.Degree * DegreeToRadian / 2.0f;
            var sine = (float)Math.Sin(theta);
            var cosine = (float)Math.Cos(theta);

            return new Rotation(
                axis.Horizontal * sine,
                axis.Vertical * sine,
                axis.Frontal * sine,
                cosine);
        }

        private static bool AreEqual(Rotation left, Rotation right)
        {
            var dotted
                = (left.Horizontal * right.Horizontal)
                + (left.Vertical * right.Vertical)
                + (left.Frontal * right.Frontal)
                + (left.Angle * right.Angle);

            const float Tolerance = 0.000001f;

            return dotted > 1.0f - Tolerance;
        }
    }
}
