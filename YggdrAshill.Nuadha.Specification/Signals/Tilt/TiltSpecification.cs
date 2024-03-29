using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Tilt))]
    internal class TiltSpecification
    {
        [TestCase(0.0f, Tilt.Minimum)]
        [TestCase(Tilt.Minimum, 0.0f)]
        [TestCase(0.0f, Tilt.Maximum)]
        [TestCase(Tilt.Maximum, 0.0f)]
        public void ShouldBeEqualToSameOne(float horizontal, float vertical)
        {
            Assert.AreEqual(new Tilt(horizontal, vertical), new Tilt(horizontal, vertical));
        }

        [TestCase(0.0f, Tilt.Minimum)]
        [TestCase(Tilt.Minimum, 0.0f)]
        [TestCase(0.0f, Tilt.Maximum)]
        [TestCase(Tilt.Maximum, 0.0f)]
        public void ShouldNotBeEqualToDifferentOne(float horizontal, float vertical)
        {
            Assert.AreNotEqual(new Tilt(horizontal, vertical), new Tilt(vertical, horizontal));
        }

        [Test]
        public void ShouldHaveCoordinate()
        {
            Assert.AreEqual(new Tilt(0.0f, 0.0f), Tilt.Origin);
            Assert.AreEqual(new Tilt(Tilt.Maximum, 0.0f), Tilt.Right);
            Assert.AreEqual(new Tilt(Tilt.Minimum, 0.0f), Tilt.Left);
            Assert.AreEqual(new Tilt(0.0f, Tilt.Maximum), Tilt.Forward);
            Assert.AreEqual(new Tilt(0.0f, Tilt.Minimum), Tilt.Backward);
        }

        [TestCase(0.0f, Tilt.Minimum)]
        [TestCase(Tilt.Minimum, 0.0f)]
        [TestCase(0.0f, Tilt.Maximum)]
        [TestCase(Tilt.Maximum, 0.0f)]
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
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(Tilt.Minimum - 0.1f, 0.0f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(Tilt.Maximum + 0.1f, 0.0f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(0.0f, Tilt.Minimum - 0.1f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Tilt(0.0f, Tilt.Maximum + 0.1f);
            });
        }
    }
}
