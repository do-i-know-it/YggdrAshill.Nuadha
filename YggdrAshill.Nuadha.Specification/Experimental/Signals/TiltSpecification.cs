using NUnit.Framework;
using YggdrAshill.Nuadha.Signals.Experimental;
using System;

namespace YggdrAshill.Nuadha.Experimental.Specification
{
    [TestFixture(TestOf = typeof(Tilt))]
    internal class TiltSpecification
    {
        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void ShouldBeEqualToSameOne(float horizontal, float vertical)
        {
            Assert.AreEqual(new Tilt(horizontal, vertical), new Tilt(horizontal, vertical));
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        public void ShouldNotBeEqualToDifferentOne(float horizontal, float vertical)
        {
            Assert.AreNotEqual(new Tilt(horizontal, vertical), new Tilt(vertical, horizontal));
        }

        [Test]
        public void ShouldHaveCoordinate()
        {
            Assert.AreEqual(new Tilt(0f, 0f), Tilt.Origin);
            Assert.AreEqual(new Tilt(1f, 0f), Tilt.Right);
            Assert.AreEqual(new Tilt(-1f, 0f), Tilt.Left);
            Assert.AreEqual(new Tilt(0f, 1f), Tilt.Upward);
            Assert.AreEqual(new Tilt(0f, -1f), Tilt.Downward);
        }

        [TestCase(0.0f, -1.0f)]
        [TestCase(-1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        [TestCase(0.0f, 0.0f)]
        public void ShouldBeReversed(float horizontal, float vertical)
        {
            Assert.AreEqual(new Tilt(-horizontal, -vertical), new Tilt(horizontal, vertical).Reversed);
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

        [Test]
        public void CannotBeGeneratedWithLengthLargerThanOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(1.0f, 1.0f);
            });
        }
    }
}
