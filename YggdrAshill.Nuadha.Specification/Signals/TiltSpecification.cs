using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
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
        public void ShouldBeInversed(float horizontal, float vertical)
        {
            var expected = new Tilt(-horizontal, -vertical);
            var signal = new Tilt(horizontal, vertical);

            Assert.AreEqual(expected, -signal);
        }

        [Test]
        public void CannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Tilt(float.NaN, 0.0f);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Tilt(0.0f, float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithValueOutOfRange()
        {
            // Horizontal lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(-1.1f, 0.0f);
            });

            // Horizontal higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(1.1f, 0.0f);
            });

            // Vertical lower than minimum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(0.0f, -1.1f);
            });

            // Vertical higher than maximum.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(0.0f, 1.1f);
            });

            // Distance larger than length.
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(1.0f, 1.0f);
            });
        }
    }
}
