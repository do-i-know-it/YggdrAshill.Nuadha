using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Direction))]
    internal class DirectionSpecification
    {
        [TestCase(0.0f, 0.0f, -1.0f)]
        [TestCase(0.0f, -1.0f, 0.0f)]
        [TestCase(-1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f)]
        public void ShouldBeInversed(float horizontal, float vertical, float frontal)
        {
            var expected = new Direction(-horizontal, -vertical, -frontal);
            var inversed = new Direction(horizontal, vertical, frontal).Inversed;

            Assert.AreEqual(expected, inversed);
        }

        [Test]
        public void CannotBeGeneratedWithNaNHorizontal()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var position = new Direction(float.NaN, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNVertical()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var position = new Direction(0.0f, float.NaN, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNFrontal()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var position = new Direction(0.0f, 0.0f, float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithHorizontalLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var position = new Direction(-1.1f, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithHorizontalHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var position = new Direction(1.1f, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithVerticalLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var position = new Direction(0.0f, -1.1f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithVerticalHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var position = new Direction(0.0f, 1.1f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithFrontalLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var position = new Direction(0.0f, 0.0f, -1.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithFrontalHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var position = new Direction(0.0f, 0.0f, 1.1f);
            });
        }
    }
}
