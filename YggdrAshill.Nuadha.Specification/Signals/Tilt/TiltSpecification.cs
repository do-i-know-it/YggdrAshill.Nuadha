using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Tilt))]
    internal class TiltSpecification
    {
        [TestCase(-1.0f, -1.0f)]
        [TestCase(1.0f, 1.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        [TestCase(0.0f, 0.0f)]
        public void ShouldBeInversed(float horizontal, float vertical)
        {
            var expected = new Tilt(-horizontal, -vertical);
            var inversed = new Tilt(horizontal, vertical).Inversed;

            Assert.AreEqual(expected, inversed);
        }

        [Test]
        public void CannotBeGeneratedWithNaNHorizontal()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Tilt(float.NaN, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNVertical()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Tilt(0.0f, float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithHorizontalLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(-1.1f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithHorizontalHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(1.1f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithVerticalLowerThanNegativeOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(0.0f, -1.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithVerticalHigherThanPositiveOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(0.0f, 1.1f);
            });
        }
    }
}
