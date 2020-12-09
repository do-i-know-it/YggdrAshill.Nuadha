using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(RotationToRotation))]
    internal class RotationToRotationSpecification
    {
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

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldRotateWhenHasAdded(float angle)
        {
            var reduction = RotationToRotation.Add;

            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var expected = RotationOf(Direction.Up, new Angle(angle * 2));

            Assert.IsTrue(AreEqual(expected, reduction.Reduce(rotation, rotation)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldBeInversedWhenHasSubtracted(float angle)
        {
            var reduction = RotationToRotation.Subtract;

            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var expected = Rotation.None;

            Assert.IsTrue(AreEqual(expected, reduction.Reduce(rotation, rotation)));
        }

        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        public void ShouldNotBeAlwaysCommutative(float angle)
        {
            var reduction = RotationToRotation.Add;

            var left = RotationOf(Direction.Forward, new Angle(angle));
            var right = RotationOf(Direction.Up, new Angle(angle));

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
            var reduction = RotationToRotation.Add;

            var left = reduction.Reduce(Rotation.None, RotationOf(Direction.Up, new Angle(angle)));
            var right = reduction.Reduce(RotationOf(Direction.Up, new Angle(angle)), Rotation.None);

            Assert.IsTrue(AreEqual(left, right));
        }

        [TestCase(-180.0f)]
        [TestCase(-90.0f)]
        [TestCase(-45.0f)]
        [TestCase(180.0f)]
        [TestCase(90.0f)]
        [TestCase(45.0f)]
        [TestCase(0.0f)]
        public void ShouldBeInversed(float angle)
        {
            var reduction = RotationToRotation.Add;

            var rotation = RotationOf(Direction.Up, new Angle(angle));

            var left = reduction.Reduce(rotation, rotation.Inversed);
            var right = reduction.Reduce(rotation.Inversed, rotation);
            Assert.IsTrue(AreEqual(Rotation.None, left));
            Assert.IsTrue(AreEqual(Rotation.None, right));
        }
    }
}
