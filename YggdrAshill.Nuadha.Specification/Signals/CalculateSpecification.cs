using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Calculation))]
    internal class CalculateSpecification
    {
        [TestCase(0.0f, 0.0f, 1.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 1.0f)]
        public void ShouldCalculatePosition(float horizontal, float vertical, float frontal, float offset)
        {
            var calculation = Calculation.Position;

            var expected = new Position(horizontal + offset, vertical + offset, frontal + offset);

            Assert.AreEqual(expected, calculation.Calculate(new Position(horizontal, vertical, frontal), new Position(offset, offset, offset)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldCalculateRotation(float angle)
        {
            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var calculation = Calculation.Rotation;

            var expected = RotationOf(Direction.Up, new Angle(angle * 2));

            Assert.IsTrue(AreEqual(expected, calculation.Calculate(rotation, rotation)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldBeInversed(float angle)
        {
            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var calculation = Calculation.Rotation;

            Assert.IsTrue(AreEqual(Rotation.None, calculation.Calculate(rotation, rotation.Inversed)));

            Assert.IsTrue(AreEqual(Rotation.None, calculation.Calculate(rotation.Inversed, rotation)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        public void ShouldNotBeAlwaysCommutative(float angle)
        {
            var left = RotationOf(Direction.Forward, new Angle(angle));
            var right = RotationOf(Direction.Up, new Angle(angle));

            var calculation = Calculation.Rotation;

            var leftRight = calculation.Calculate(left, right);
            var rightLeft = calculation.Calculate(right, left);

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

            var calculation = Calculation.Rotation;

            Assert.AreEqual(rotation, calculation.Calculate(rotation, Rotation.None));
         
            Assert.AreEqual(rotation, calculation.Calculate(Rotation.None, rotation));
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
