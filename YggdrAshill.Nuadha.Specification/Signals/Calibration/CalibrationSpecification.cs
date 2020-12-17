using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Calibration))]
    internal class CalibrationSpecification
    {
        [TestCase(0.0f, 0.0f, 1.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 1.0f)]
        public void ShouldCalibratePosition(float horizontal, float vertical, float frontal, float offset)
        {
            var correction = Calibration.Position(() => new Position(offset, offset, offset));

            var position = new Position(horizontal, vertical, frontal);
            var expected = new Position(horizontal + offset, vertical + offset, frontal + offset);

            Assert.AreEqual(expected, correction.Correct(position));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldCalibrateRotation(float angle)
        {
            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var correction = Calibration.Rotation(() => rotation);

            var expected = RotationOf(Direction.Up, new Angle(angle * 2));

            Assert.IsTrue(AreEqual(expected, correction.Correct(rotation)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldBeInversed(float angle)
        {
            var rotation = RotationOf(Direction.Up, new Angle(angle));
            
            var correction = Calibration.Rotation(() => rotation.Inversed);

            Assert.IsTrue(AreEqual(Rotation.None, correction.Correct(rotation)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        public void ShouldNotBeAlwaysCommutative(float angle)
        {
            var left = RotationOf(Direction.Forward, new Angle(angle));
            var right = RotationOf(Direction.Up, new Angle(angle));

            var leftRight = Calibration.Rotation(() => right).Correct(left);
            var rightLeft = Calibration.Rotation(() => left).Correct(right);

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
            var left = Calibration.Rotation(() => rotation).Correct(Rotation.None);
            var right = Calibration.Rotation(() => Rotation.None).Correct(rotation);

            Assert.IsTrue(AreEqual(left, right));
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
