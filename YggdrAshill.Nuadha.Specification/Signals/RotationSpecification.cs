using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Rotation))]
    internal class RotationSpecification
    {
        [TestCase(0.0f, 0.0f, 1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f)]
        public void ShouldBeInversed(float horizontal, float vertical, float frontal, float angle)
        {
            var expected = new Rotation(-horizontal, -vertical, -frontal, angle);
            var rotation = new Rotation(horizontal, vertical, frontal, angle);
            var inversed = rotation.Inversed;

            Assert.AreEqual(expected, inversed);
        }

        [Test]
        public void CannotBeGeneratedWithHorizontalLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rotation = new Rotation(-1.1f, 0.0f, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithHorizontalHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rotation = new Rotation(1.1f, 0.0f, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithVerticalLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rotation = new Rotation(0.0f, -1.1f, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithVerticalHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rotation = new Rotation(0.0f, 1.1f, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithFrontalLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rotation = new Rotation(0.0f, 0.0f, -1.1f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithFrontalHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rotation = new Rotation(0.0f, 0.0f, 1.1f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithAngleLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rotation = new Rotation(0.0f, 0.0f, 0.0f, -1.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithAngleHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var rotation = new Rotation(0.0f, 0.0f, 0.0f, 1.1f);
            });
        }
    }
}
