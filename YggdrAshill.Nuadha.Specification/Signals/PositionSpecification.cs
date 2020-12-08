using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Position))]
    internal class PositionSpecification
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
            var expected = new Position(-horizontal, -vertical, -frontal);
            var inversed = new Position(horizontal, vertical, frontal).Inversed;

            Assert.AreEqual(expected, inversed);
        }

        [Test]
        public void CannotBeGeneratedWithNaNHorizontal()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Position(float.NaN, 0.0f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNVertical()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Position(0.0f, float.NaN, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNFrontal()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Position(0.0f, 0.0f, float.NaN);
            });
        }
    }
}
